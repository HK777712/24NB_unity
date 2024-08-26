using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ROS2;
using topicSt = std_msgs.msg.String;
using System.Linq;
public class SubCon : MonoBehaviour
{
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private ISubscription<topicSt> c1_sub;
    private ISubscription<topicSt> c2_sub;
    private ISubscription<topicSt> c3_sub;
    private ISubscription<topicSt> p1_sub;
    [SerializeField] private GameObject uiope;
    private PanelContoroller panecon;
    
    private int target_num = 1;
    private bool is_oya = false;
    private bool is_admin = false;
    private bool _destroy = false;
    private Queue<string> recqueue = new Queue<string>();
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out ros2Unity);
        panecon = GameObject.Find("UIOpe").GetComponent<PanelContoroller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Environment.GetEnvironmentVariable("ROS_DOMAIN_ID") =="7"){
            if(ros2Unity.Ok()){
                if(ros2Node == null){
                    // Nodeの名前を指定する
                    ros2Node = ros2Unity.CreateNode("UnitySubNode");
                    //トピックの名前と型を指定する
                    c1_sub = ros2Node.CreateSubscription<topicSt>("/c1",C1_callback);
                    c2_sub = ros2Node.CreateSubscription<topicSt>("/c2",C2_callback);
                    c3_sub = ros2Node.CreateSubscription<topicSt>("/c3",C3_callback);
                    p1_sub = ros2Node.CreateSubscription<topicSt>("/p1",P1_callback);
                    Debug.Log("sub");
                    _destroy = false;
                }
            }
            target_num = uiope.GetComponent<TargetController>().GettargetNum(); 
            is_oya = uiope.GetComponent<PanelContoroller>().Getisoya();
            is_admin = uiope.GetComponent<PanelContoroller>().Getisadmin();
            while(recqueue.Count != 0){
                Debug.Log(recqueue.Dequeue());
            }
        }else{
            if(!_destroy){
                ros2Unity.RemoveNode(ros2Node);
                ros2Node.RemoveSubscription<topicSt>(p1_sub);
                ros2Node.RemoveSubscription<topicSt>(c1_sub);
                ros2Node.RemoveSubscription<topicSt>(c2_sub);
                ros2Node.RemoveSubscription<topicSt>(c3_sub);
                ros2Node = null;
                _destroy = true;
            }
        }
    }
    void C1_callback(topicSt msg)
    {
        string topicMsg = msg.Data;
        recqueue.Enqueue("/c1:"+topicMsg);
        if(!is_oya & target_num == 1 & topicMsg == "p"){
            panecon.SubPause = true;
        }
    }
    
    void C2_callback(topicSt msg)
    {
        string topicMsg = msg.Data;
        recqueue.Enqueue("/c2:"+topicMsg);
        if(!is_oya & target_num == 2 & topicMsg == "p"){
            panecon.SubPause = true;
        }
    }
    void C3_callback(topicSt msg)
    {
        string topicMsg = msg.Data;
        recqueue.Enqueue("/c3:"+topicMsg);
        if(!is_oya & target_num == 3 & topicMsg == "p"){
            panecon.SubPause = true;
        }
    }
    void P1_callback(topicSt msg)
    {
        string topicMsg = msg.Data;
        recqueue.Enqueue("/p1:"+topicMsg);
        if(is_oya & topicMsg == "p"){
            panecon.SubPause = true;
        }
    }
    
}
