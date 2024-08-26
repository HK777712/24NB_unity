using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[System.Serializable] // <- これが大事。忘れずに
public class Ds4button {
    public ButtonList ds4button;
    public Button button;
    public PanelList panel;
}
public class Ds4Con : MonoBehaviour
{
    [SerializeField] GameObject uiope;
    [SerializeField] List<Ds4button> ds4data;
    private bool connected = false;
    private bool is_oya;
    private bool is_main;
    void Update(){
        /*
        if(Input.GetButtonDown(button.ToString())){
            Debug.Log(button.ToString());
        }
        */
        is_oya = uiope.GetComponent<PanelContoroller>().Getisoya();
        is_main = uiope.GetComponent<PanelContoroller>().Getismain();
        PanelList nowpanel;
        if (is_main && is_oya){
            nowpanel = PanelList.Oyamain;
        }else if(is_main && !is_oya){
            nowpanel = PanelList.Komain;
        }else if(!is_main && is_oya){
            nowpanel = PanelList.Oyacon;
        }else{
            nowpanel = PanelList.Kocon;
        }
        for(int count = 0;count < ds4data.Count;count++){
            ButtonList list = ds4data[count].ds4button;
            Button button1 = ds4data[count].button;
            PanelList panel1 = ds4data[count].panel;
            if(Input.GetButtonDown(list.ToString())){
                if(panel1 == nowpanel || panel1 == PanelList.CMD){
                    //Debug.Log(list.ToString());
                    //button1.onClick.Invoke();
                }
            }
        }
    }
    IEnumerator CheckForControllers() {
        while (true) {
            /*
            var controllers = Input.GetJoystickNames();

            if (!connected && controllers.Length > 0) {
                connected = true;
                Debug.Log("Connected");
            
            } else if (connected && controllers.Length == 0) {         
                connected = false;
                Debug.Log("Disconnected");
            }
            */
            //Debug.Log(Input.GetButtonDown("Jump"));

            yield return new WaitForFixedUpdate();
        }
    }

    void Awake() {
        StartCoroutine(CheckForControllers());
    }
}
/*
public enum ButtonList
{
    Sikaku,Batu,Maru,Sankaku,L1,L2,R1,R2,Lo,Ro,Up,Down,Right,Left
}
public enum PanelList
{
    Oyacon,Oyamain,Kocon,Komain,CMD,Null
}
*/