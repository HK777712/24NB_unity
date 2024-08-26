using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ROS2;
using topicSt = std_msgs.msg.String;
using Ts = twistring.msg.Twistring;
[System.Serializable] // <- これが大事。忘れずに
public class Data {
    public Button button;
    public string topic;
}
public class DataList : MonoBehaviour
{
    [SerializeField] List<Data> data;
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private IPublisher<Ts> chatter_pub;
    private PubConCutom pubcon;
    
    private string value="7";
    private sbyte testnum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        //Environment.SetEnvironmentVariable("ROS_DOMAIN_ID", "7");
        TryGetComponent(out ros2Unity);
        Debug.Log(data.Count);
        pubcon = GameObject.Find("Pubcontoroller").GetComponent<PubConCutom>();
        
        for(int count = 0;count < data.Count;count++){
            Button button1 = data[count].button;
            string string1 = data[count].topic;
            //Debug.Log("num:" + count);
            button1.onClick.AddListener(() => SendMsg(string1));
        }
    }
    void Update()
    {
        if(Environment.GetEnvironmentVariable("ROS_DOMAIN_ID") == "7"){
            if(ros2Unity.Ok()){
                if(ros2Node == null){
                    // Nodeの名前を指定する
                    ros2Node = ros2Unity.CreateNode("UnityBallNode");
                    //トピックの名前と型を指定する
                    chatter_pub = ros2Node.CreatePublisher<Ts>("/unity");
                    Debug.Log("node:null");
                    value = Environment.GetEnvironmentVariable("ROS_DOMAIN_ID");
                }
                /*
                if(value != Environment.GetEnvironmentVariable("ROS_DOMAIN_ID")){
                    value = Environment.GetEnvironmentVariable("ROS_DOMAIN_ID");
                    //ros2Unity.RemoveNode(ros2Node);
                    Debug.Log(ros2Node);
                }
                */
            }
        }
    }
    void Rem(){
        ros2Node.RemovePublisher<topicSt>(chatter_pub);
        ros2Unity.RemoveNode(ros2Node);
        Debug.Log("rem");
    }
    void Make(){
        
    }
    void SendMsg(string msg)
    {
        Ts topicmsg = new Ts();
        topicmsg.Id = testnum;
        topicmsg.Cmd = "n."+testnum.ToString()+":d."+msg;
        topicmsg.Twist.Angular.X = testnum;
        topicmsg.Twist.Angular.Y = (-1)*testnum;
        //chatter_pub.Publish(topicmsg);
        Debug.Log("kotti;"+Environment.GetEnvironmentVariable("ROS_DOMAIN_ID"));
        //Debug.Log("poti");
        pubcon.queue.Enqueue(msg);
        if(testnum<10) testnum+=1;
        else testnum=0;
    }
}
