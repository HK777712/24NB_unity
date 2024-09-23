using UnityEngine;
using ROS2;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

using Ls = sensor_msgs.msg.LaserScan;

public class LaserScanSubscriber : MonoBehaviour
{
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private ISubscription<Ls> ls_sub;
    private float[] scanRangesArray;
    private float scanAngleMin = 0;
    private float scanAngleMax = 0;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out ros2Unity);
    }

    // Update is called once per frame
    void Update()
    {
        if (ros2Unity.Ok())
        {
            if (ros2Node == null)
            {
                // Nodeの名前を指定する
                ros2Node = ros2Unity.CreateNode("Lasersub");
                //トピックの名前と型を指定する
                ls_sub = ros2Node.CreateSubscription<Ls>("/scan",Callback);
            }
        }
    }
    void Callback(Ls subls){
        scanRangesArray = subls.Ranges;
        scanAngleMax = subls.Angle_max;
        scanAngleMin = subls.Angle_min;
    }
    public float[] GetScanRanges(){
        return scanRangesArray;
    }
    public float GetScanAngleMin(){
        return scanAngleMin;
    }
    public float GetScanAngleMax(){
        return scanAngleMax;
    }
}
