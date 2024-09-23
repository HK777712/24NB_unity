using System;
using UnityEngine;
using UnityEngine.UI;

public class SetIDkasu : MonoBehaviour
{
    void Start(){
        Change("7");
    }
    void Change(string num)
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
}
