using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ROS2;
using topicSt = std_msgs.msg.String;
using twist = geometry_msgs.msg.Twist;
using Ts = twistring.msg.Twistring;
using System.Linq;
using Unity.VisualScripting;
public class PubConCutom : MonoBehaviour
{
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private IPublisher<Ts> pub;

    private string button_cmd = "";
    [SerializeField] private GameObject uiope;
    private int target_num = 1;
    private bool is_oya = false;
    private bool is_admin = false;
    private bool _destroy = false;
    [System.NonSerialized] public Queue<string> queue = new Queue<string>();
    [System.NonSerialized] public Queue<twist> twistmsgs = new Queue<twist>();
    private IEnumerator routine;
    private string oldid = "7"; 
    private NewDS4con ds;
    private bool kyokabo = false;
    public GameObject rocktoggle;
    // Start is called before the first frame update
    void Start()
    {
        ds= GameObject.Find("UIOpe").GetComponent<NewDS4con>();
        TryGetComponent(out ros2Unity);
        routine = PublishTwistring();
    }

    // Update is called once per frame
    void Update()
    {
        if(Environment.GetEnvironmentVariable("ROS_DOMAIN_ID") =="7" || Environment.GetEnvironmentVariable("ROS_DOMAIN_ID") =="8"){
            if(oldid!=Environment.GetEnvironmentVariable("ROS_DOMAIN_ID"))Rem();
            oldid = Environment.GetEnvironmentVariable("ROS_DOMAIN_ID");
            if(ros2Unity.Ok()){
                if(ros2Node == null){
                    Debug.Log("else");
                    // Nodeの名前を指定する
                    ros2Node = ros2Unity.CreateNode("UnityNode");
                    //トピックの名前と型を指定する
                    if(Environment.GetEnvironmentVariable("ROS_DOMAIN_ID") =="7")pub = ros2Node.CreatePublisher<Ts>("/R2");
                    else if(Environment.GetEnvironmentVariable("ROS_DOMAIN_ID") =="8")pub = ros2Node.CreatePublisher<Ts>("/R2P");
                    
                    _destroy = false;
                    StartCoroutine(routine);
                }
                
                target_num = uiope.GetComponent<TargetController>().GettargetNum(); 
                is_oya = uiope.GetComponent<PanelContoroller>().Getisoya();
                is_admin = uiope.GetComponent<PanelContoroller>().Getisadmin();
            }
        }else{
            Rem();
        }
    }
    void Rem(){
        if(!_destroy&&ros2Node != null){
            StopCoroutine(routine);
            ros2Node.RemovePublisher<Ts>(pub);
            ros2Unity.RemoveNode(ros2Node);
            ros2Node = null;
            Debug.Log("naiyo!");
            Debug.Log(ros2Node);
            _destroy = true;
        }
    }
    IEnumerator PublishTwistring(){
        while(true){
            Ts msg = new Ts();
            if(queue.Count!=0)msg.Cmd = queue.Dequeue();
            //else if(ds.Getsankaku())msg.Cmd = "rock";
            while(twistmsgs.Count!=0)msg.Twist = twistmsgs.Dequeue();
            //if(Environment.GetEnvironmentVariable("ROS_DOMAIN_ID") =="7"){
            if(msg.Cmd == "allpause"){
                if(is_admin){
                    msg.Cmd = "p";
                    for(sbyte i = 0; i < 4;i++){
                        msg.Id = i;
                        pub.Publish(msg);
                    }
                }
            }else if(msg.Cmd == "red"){
                msg.Cmd = "team red";
                for(sbyte i = 0; i < 4;i++){
                    msg.Id = i;
                    pub.Publish(msg);
                }
            }else if(msg.Cmd == "blue"){
                msg.Cmd = "team blue";
                for(sbyte i = 0; i < 4;i++){
                    msg.Id = i;
                    pub.Publish(msg);
                }
            }else if(msg.Cmd == "kyoka"){
                kyokabo = true;
            }else if(msg.Cmd == "rock"){
                kyokabo = false;
            }else if(msg.Cmd == "s"){
                if(kyokabo){
                    msg.Id=0;
                    pub.Publish(msg);
                    rocktoggle.GetComponent<IOSButton>().SetOff();
                }
            }else if(is_oya){
                msg.Id = 0;
                pub.Publish(msg);
            }else{
                msg.Id = Convert.ToSByte(target_num);
                pub.Publish(msg);
                //if(msg.Cmd != "")Debug.Log(msg.Cmd);
            }
            //}
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
        }
    }
    void Awake() {
    }
}
