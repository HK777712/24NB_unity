using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ROS2;
using topicSt = std_msgs.msg.String;
using twist = geometry_msgs.msg.Twist;
using posestm = geometry_msgs.msg.PoseStamped;
using Ts = twistring.msg.Twistring;
public class Domaintest : MonoBehaviour
{
    [SerializeField] List<Data> r1data;
    public FixedJoystick XYJoy;
    public FixedJoystick ZJoy;
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    //private IPublisher<topicSt> cmd_pub;
    //private IPublisher<twist> cmd_vel_pub;
    private IPublisher<Ts> r1_pub;
    private IPublisher<posestm> goal_pub;
    private ISubscription<twist> nav_sub;
    private PanelContoroller panecon;
    private NewDS4con dscon;
    private bool _destroy = false;
    [System.NonSerialized] public Queue<string> stmsgs = new Queue<string>();
    private Queue<twist> twists = new Queue<twist>();
    private Queue<posestm> posemsgs = new Queue<posestm>();
    IEnumerator routine;
    private Vector2 leftdsjoy;
    private Vector2 rightdsjoy;
    private bool servo0 = true;
    private bool servo1 = true;
    private readonly Vector3 lefthome = new(0,3.5f,0);
    private readonly Vector3 righthome = new(0,0,0);
    private readonly Vector3 syasyutu = new(1.5f,1.75f,0);

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out ros2Unity);
        routine = Sentpub();
        dscon = GameObject.Find("UIOpe").GetComponent<NewDS4con>();
        panecon = GameObject.Find("UIOpe").GetComponent<PanelContoroller>();
        for(int count = 0;count < r1data.Count;count++){
            Button button1 = r1data[count].button;
            string string1 = r1data[count].topic;
            //Debug.Log("num:" + count);
            button1.onClick.AddListener(() => SendMsg(string1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Environment.GetEnvironmentVariable("ROS_DOMAIN_ID") == "2"){
            if(ros2Unity.Ok()){
                if(ros2Node == null){
                    ros2Node = ros2Unity.CreateNode("UnityR1Node");
                    QualityOfServiceProfile qos = new QualityOfServiceProfile();
                    qos.SetHistory(HistoryPolicy.QOS_POLICY_HISTORY_SYSTEM_DEFAULT,10);
                    qos.SetDurability(DurabilityPolicy.QOS_POLICY_DURABILITY_SYSTEM_DEFAULT);
                    //qos.SetReliability(ReliabilityPolicy.QOS_POLICY_RELIABILITY_BEST_EFFORT);
                    //トピックの名前と型を指定する
                    //cmd_pub = ros2Node.CreatePublisher<topicSt>("/cmd",qos);
                    //cmd_vel_pub = ros2Node.CreatePublisher<twist>("/cmd_vel",qos);
                    r1_pub = ros2Node.CreatePublisher<Ts>("/R1_control",qos);
                    goal_pub = ros2Node.CreatePublisher<posestm>("/goal_pose",qos);
                    nav_sub = ros2Node.CreateSubscription<twist>("/cmd_vel_nav",callback,qos);
                    //Debug.Log("kasu");
                    StartCoroutine(routine);
                    _destroy = false;
                }
            }
        }else{
            if(!_destroy &&ros2Node != null){
                StopCoroutine(routine);
                routine = null;
                routine = Sentpub();
                stmsgs = new Queue<string>();
                posemsgs = new Queue<posestm>();
                //ros2Node.RemovePublisher<topicSt>(cmd_pub);
                //ros2Node.RemovePublisher<twist>(cmd_vel_pub);
                ros2Node.RemovePublisher<Ts>(r1_pub);
                ros2Node.RemovePublisher<posestm>(goal_pub);
                ros2Unity.RemoveNode(ros2Node);
                ros2Node = null;
                _destroy = true;
            }
        }
    }
    void callback(twist msg){
        if(panecon.Getisnav()){
            /*
            Ts tsmsg = new Ts();
            tsmsg.Twist = msg;
            r1_pub.Publish(tsmsg);
            */
            //twists.Enqueue(msg);
        }
    }
    void SendMsg(string data){
        string enqueuedata;
        if(data == "lh")Sendpose(lefthome); 
        if(data == "rh")Sendpose(righthome); 
        if(data == "go")Sendpose(syasyutu);
        if(data == "s 0"){
            servo0 = !servo0;
            enqueuedata = data +" "+ (servo0 ? 1 : 0);
        }else if(data == "s 1"){
            servo1 = !servo1;
            enqueuedata = data +" "+ (servo1 ? 1 : 0);
        }else{
            enqueuedata = data;
        }
        stmsgs.Enqueue(enqueuedata);
    }
    void Sendpose(Vector3 vec){
        posestm msg = new posestm();
        msg.Pose.Position.X = vec.x;
        msg.Pose.Position.Y = vec.y;
        msg.Pose.Position.Z = vec.z;
        posemsgs.Enqueue(msg);
    }
    IEnumerator Sentpub(){
        while(true){
            Ts msg = new Ts();
            leftdsjoy = dscon.Getleftjoy();
            rightdsjoy = dscon.Getrightjoy();
            if(!panecon.Getisnav()){
                twist sendtwist = new twist();
                if(leftdsjoy.y == 0){
                    sendtwist.Linear.X = XYJoy.Vertical;
                }else{
                    sendtwist.Linear.X = leftdsjoy.y;
                }
                if(leftdsjoy.x == 0){
                    sendtwist.Linear.Y = (-1)*XYJoy.Horizontal;
                }else{
                    sendtwist.Linear.Y = (-1)*leftdsjoy.x;
                }
                if(rightdsjoy.x == 0){
                    sendtwist.Angular.Z = (-1)*ZJoy.Horizontal;
                }else{
                    sendtwist.Angular.Z = (-1)*rightdsjoy.x;
                }
                msg.Twist = sendtwist;
                if(stmsgs.Count!=0)msg.Cmd = stmsgs.Dequeue();
                r1_pub.Publish(msg);
            }else{
                if(twists.Count!=0){
                    msg.Twist = twists.Dequeue();
                    r1_pub.Publish(msg);
                }
                if(stmsgs.Count!=0){
                    msg.Cmd = stmsgs.Dequeue();
                    r1_pub.Publish(msg);
                }
            }
            if(posemsgs.Count!=0)goal_pub.Publish(posemsgs.Dequeue());
            //Debug.Log("imihu");
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
        }
    }
}
