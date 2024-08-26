using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ROS2;
using topicSt = std_msgs.msg.String;
public class Domaintest : MonoBehaviour
{
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private IPublisher<std_msgs.msg.String> kasuchatter_pub;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out ros2Unity);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Environment.GetEnvironmentVariable("ROS_DOMAIN_ID") == "2"){
            if(ros2Unity.Ok()){
                if(ros2Node == null){
                    ros2Node = ros2Unity.CreateNode("UnitykasuNode");
                    //トピックの名前と型を指定する
                    kasuchatter_pub = ros2Node.CreatePublisher<topicSt>("/kasu");
                    Debug.Log("kasu");
                }
                i++;
                std_msgs.msg.String msg = new std_msgs.msg.String();
                msg.Data = "Unity ROS2 sending: hello " + i;
                kasuchatter_pub.Publish(msg);
                //if(i%100==0){Debug.Log(Environment.GetEnvironmentVariable("ROS_DOMAIN_ID"));}
            }
        }
    }
}
