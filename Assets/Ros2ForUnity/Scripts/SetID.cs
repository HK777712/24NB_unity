using UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading;
using ROS2;
using TMPro;
using UnityEngine.UI;

namespace ROS2{
    public class SetID : MonoBehaviour
    {
        private object mutex = new object();
        public Button _7button;
        public Button _2button;
        private bool isr1;
        private bool isoya;
        private string imadoko="7"; //2 r1 7 coki 8oya
        private PanelContoroller panecon;
        public TMP_Text tmp;
        void Start(){
            if(PlayerPrefs.GetString("domain")=="0"){
                Set("8");
            }else if(PlayerPrefs.GetString("domain")=="4"){
                Set("2");
            }else{
                Set("7");
            }
            _7button.onClick.AddListener(() => Change("7"));
            _2button.onClick.AddListener(() => Change("2"));
            panecon = GameObject.Find("UIOpe").GetComponent<PanelContoroller>();
        }
        void Update(){
            string now = "7";
            isr1 = panecon.Getisr1();
            isoya = panecon.Getisoya();
            if(isr1){
                now = "2";
            }else if(isoya){
                now = "32";
            }else{
                now="7";
            }
            if(now != imadoko){
                //Change(now);
                imadoko = now;
            }
            tmp.SetText(Environment.GetEnvironmentVariable("ROS_DOMAIN_ID"));
        }
        void Set(string num)
        {
            // 現在設定されているIDを調べる
            string value = Environment.GetEnvironmentVariable("ROS_DOMAIN_ID");
            // ROS_DOMAIN_IDに123を設定する
            Environment.SetEnvironmentVariable("ROS_DOMAIN_ID", num);
            Debug.Log("DOMAIN_ID set OK");
            // 上手く設定できているか確認する
            value = Environment.GetEnvironmentVariable("ROS_DOMAIN_ID");
            Debug.Log("current ROS_DOMAIN_ID:" + value);
            
            Debug.Log("domain;="+PlayerPrefs.GetString("domain"));
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
