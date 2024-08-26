using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ROS2;
using topicSt = std_msgs.msg.String;
using Ts = twistring.msg.Twistring;
using System.Linq;
public class SubConCutom : MonoBehaviour
{
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private ISubscription<Ts> sub;
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
                    sub = ros2Node.CreateSubscription<Ts>("/r2",callback);
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
                ros2Node.RemoveSubscription<Ts>(sub);
                ros2Unity.RemoveNode(ros2Node);
                ros2Node = null;
                _destroy = true;
            }
        }
    }
    void callback(Ts msg)
    {
        if(msg.Cmd!="")recqueue.Enqueue("/r2."+msg.Id+":"+msg.Cmd);
        if(msg.Cmd == "p" && (!is_oya && msg.Id == target_num || is_oya && msg.Id == 0)){
            panecon.SubPause = true;
        }
    }
    
}
