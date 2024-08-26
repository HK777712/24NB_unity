using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ROS2;
using topicSt = std_msgs.msg.String;
using System.Linq;
public class Domainsub : MonoBehaviour
{
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private ISubscription<topicSt> c1kasu_sub;
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out ros2Unity);
    }

    // Update is called once per frame
    void Update()
    {
        if(ros2Unity.Ok()){
            if(ros2Node == null){
                // Nodeの名前を指定する
                ros2Node = ros2Unity.CreateNode("UnitykasuSubNode");
                //トピックの名前と型を指定する
                c1kasu_sub = ros2Node.CreateSubscription<topicSt>("/kasu",C1_callback);
            }
        }
    }
    void C1_callback(topicSt msg)
    {
        //Debug.Log(msg.Data);
        
    }    
}
