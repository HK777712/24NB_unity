using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Kogane;
public class Reload : MonoBehaviour
{
    public Button button;
    private TargetController target;
    private PanelContoroller panecon;
    void Start(){
        target = GameObject.Find("UIOpe").GetComponent<TargetController>();
        panecon = GameObject.Find("UIOpe").GetComponent<PanelContoroller>();
        button.onClick.AddListener(ReloadButton);
    }
    void Update(){
        string num;
        if(panecon.Getisoya()){
            num = "0";
        }else if(panecon.Getisr1()){
            num = "4";
        }else{
            num = target.GettargetNum().ToString();
        }
        PlayerPrefs.SetString("domain",num);
        PlayerPrefs.Save();
    }
    void ReloadButton(){
        string num;
        if(panecon.Getisoya()){
            num = "0";
        }else if(panecon.Getisr1()){
            num = "4";
        }else{
            num = target.GettargetNum().ToString();
        }
        PlayerPrefs.SetString("domain",num);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("domain")+";;"+PlayerPrefs.GetInt("kengen").ToString());
        ApplicationRestarter.Restart();
    }
}
