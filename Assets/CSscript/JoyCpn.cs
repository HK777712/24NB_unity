using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using twist = geometry_msgs.msg.Twist;

public class JoyCpn : MonoBehaviour
{
    public FixedJoystick childYJoy;
    public FixedJoystick childZJoy;
    public FixedJoystick parentXYJoy;
    public FixedJoystick parentZJoy;
    [SerializeField] private GameObject uiope;
    private PubConCutom pubcon;
    private bool is_oya;
    private bool is_main;
    private Vector2 leftdsjoy;
    private Vector2 rightdsjoy;
    void Start(){
        pubcon = GameObject.Find("Pubcontoroller").GetComponent<PubConCutom>();
        StartCoroutine(JoyAsync());
    }

    // Update is called once per frame
    void Update(){
        is_oya = uiope.GetComponent<PanelContoroller>().Getisoya();
        is_main = uiope.GetComponent<PanelContoroller>().Getismain();
        leftdsjoy = uiope.GetComponent<NewDS4con>().Getleftjoy();
        rightdsjoy = uiope.GetComponent<NewDS4con>().Getrightjoy();
    }
    IEnumerator JoyAsync(){
        while(true){
            yield return new WaitForFixedUpdate();
            twist sendtwist = new twist();
            if(is_oya){
                if(leftdsjoy.y == 0){
                    sendtwist.Linear.X = parentXYJoy.Vertical;
                }else{
                    sendtwist.Linear.X = leftdsjoy.y;
                }
                /*
                if(leftdsjoy.x == 0){
                    sendtwist.Linear.Y = (-1)*parentXYJoy.Horizontal;
                }else{
                    sendtwist.Linear.Y = (-1)*leftdsjoy.x;
                }
                */
                if(rightdsjoy.x == 0){
                    sendtwist.Angular.Z = (-1)*parentZJoy.Horizontal;
                }else{
                    sendtwist.Angular.Z = (-1)*rightdsjoy.x;
                }
            }else{
                if(leftdsjoy.y == 0){
                    sendtwist.Linear.X = childYJoy.Vertical;
                }else{
                    sendtwist.Linear.X = leftdsjoy.y;
                }
                if(rightdsjoy.y == 0){
                    sendtwist.Angular.X = childZJoy.Vertical;
                }else{
                    sendtwist.Angular.X = rightdsjoy.y;
                }
            }
            if(is_main){sendtwist = new twist();}
            pubcon.twistmsgs.Enqueue(sendtwist);
        }
        //yield return null;
    }
}
