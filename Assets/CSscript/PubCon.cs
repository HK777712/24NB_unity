using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ROS2;
using topicSt = std_msgs.msg.String;
using twist = geometry_msgs.msg.Twist;
using System.Linq;
public class PubCon : MonoBehaviour
{
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private IPublisher<topicSt> r1_pub;
    private IPublisher<topicSt> p1_pub;
    private IPublisher<topicSt> c1_pub;
    private IPublisher<topicSt> c2_pub;
    private IPublisher<topicSt> c3_pub;
    private IPublisher<twist> p1_twi;
    private IPublisher<twist> c1_twi;
    private IPublisher<twist> c2_twi;
    private IPublisher<twist> c3_twi;

    private string button_cmd = "";
    [SerializeField] private GameObject uiope;
    private int target_num = 1;
    private bool is_oya = false;
    private bool is_admin = false;
    private bool _destroy = false;
    [System.NonSerialized] public Queue<string> queue = new Queue<string>();
    [System.NonSerialized] public Queue<twist> twistmsgs = new Queue<twist>();
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out ros2Unity);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Environment.GetEnvironmentVariable("ROS_DOMAIN_ID") =="7"){
            if(ros2Unity.Ok()){
                if(ros2Node == null){
                    // Nodeの名前を指定する
                    ros2Node = ros2Unity.CreateNode("UnityNode");
                    //トピックの名前と型を指定する
                    r1_pub = ros2Node.CreatePublisher<topicSt>("/cmd");
                    p1_pub = ros2Node.CreatePublisher<topicSt>("/p1");
                    c1_pub = ros2Node.CreatePublisher<topicSt>("/c1");
                    c2_pub = ros2Node.CreatePublisher<topicSt>("/c2");
                    c3_pub = ros2Node.CreatePublisher<topicSt>("/c3");
                    p1_twi = ros2Node.CreatePublisher<twist>("/p1_twi");
                    c1_twi = ros2Node.CreatePublisher<twist>("/c1_twi");
                    c2_twi = ros2Node.CreatePublisher<twist>("/c2_twi");
                    c3_twi = ros2Node.CreatePublisher<twist>("/c3_twi");
                    Debug.Log("else");
                    _destroy = false;
                }
                
                target_num = uiope.GetComponent<TargetController>().GettargetNum(); 
                is_oya = uiope.GetComponent<PanelContoroller>().Getisoya();
                is_admin = uiope.GetComponent<PanelContoroller>().Getisadmin();
                while(queue.Count != 0){
                    button_cmd = queue.Dequeue();
                    SendMsg(button_cmd);
                }
                while(twistmsgs.Count != 0){
                    twist msg = twistmsgs.Dequeue();
                    SendtwistMsg(msg);
                }
            }
        }else{
            if(!_destroy){
                ros2Unity.RemoveNode(ros2Node);
                ros2Node.RemovePublisher<topicSt>(r1_pub);
                ros2Node.RemovePublisher<topicSt>(p1_pub);
                ros2Node.RemovePublisher<topicSt>(c1_pub);
                ros2Node.RemovePublisher<topicSt>(c2_pub);
                ros2Node.RemovePublisher<topicSt>(c3_pub);
                ros2Node.RemovePublisher<topicSt>(p1_twi);
                ros2Node.RemovePublisher<topicSt>(c1_twi);
                ros2Node.RemovePublisher<topicSt>(c2_twi);
                ros2Node.RemovePublisher<topicSt>(c3_twi);
                ros2Node = null;
                Debug.Log("naiyo!");
                Debug.Log(ros2Node);
                _destroy = true;
            }
        }
    }
    void SendMsg(string topicMsg)
    {
        topicSt msg = new topicSt();
        msg.Data = topicMsg;
        if(topicMsg == "allpause"){
            if(is_admin){
                msg.Data = "p";
                r1_pub.Publish(msg);
                p1_pub.Publish(msg);
                c1_pub.Publish(msg);
                c2_pub.Publish(msg);
                c3_pub.Publish(msg);
            }
        }else if(is_oya){
            p1_pub.Publish(msg);
        }else if(target_num == 1){
            c1_pub.Publish(msg);
        }else if(target_num == 2){
            c2_pub.Publish(msg);
        }else if(target_num == 3){
            c3_pub.Publish(msg);
        }
        //Debug.Log("send:" + topicMsg);
    }
    void SendtwistMsg(twist twisttopicmsg){
        if(is_oya){
            p1_twi.Publish(twisttopicmsg);
        }else if(target_num == 1){
            c1_twi.Publish(twisttopicmsg);
        }else if(target_num == 2){
            c2_twi.Publish(twisttopicmsg);
        }else if(target_num == 3){
            c3_twi.Publish(twisttopicmsg);
        }
    }
}
