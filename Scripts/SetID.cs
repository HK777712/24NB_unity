using UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading;
using ROS2;
using UnityEngine.UI;

namespace ROS2{
    public class SetID : MonoBehaviour
    {
        private object mutex = new object();
        public Button _7button;
        public Button _2button;
        void Start(){
            Set("7");
            _7button.onClick.AddListener(() => Change("7"));
            _2button.onClick.AddListener(() => Change("2"));
        }
        void Set(string num)
        {
            // 現在設定されているIDを調べる
            string value = Environment.GetEnvironmentVariable("ROS_DOMAIN_ID");
            Debug.Log("current ROS_DOMAIN_ID:" + value + "\n");
            // ROS_DOMAIN_IDに123を設定する
            Environment.SetEnvironmentVariable("ROS_DOMAIN_ID", num);
            Debug.Log("DOMAIN_ID set OK\n");
            // 上手く設定できているか確認する
            value = Environment.GetEnvironmentVariable("ROS_DOMAIN_ID");
            Debug.Log("current ROS_DOMAIN_ID:" + value + "\n");
        }
        void Change(string domainid){
            ROS2ForUnity ros2forUnity = new ROS2ForUnity();
            Set("11");
            ros2forUnity.DestroyROS2ForUnity();
            //ros2forUnity =null;
            Set(domainid);
            ros2forUnity = new ROS2ForUnity();
            
        }
    }
}
