using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelContoroller : MonoBehaviour
{
    [SerializeField] GameObject childPanel;      //メインカメラ格納用
    [SerializeField] GameObject parentPanel;       //サブカメラ格納用 
    [SerializeField] GameObject parentMainPanel;
    [SerializeField] GameObject childMainPanel;
    [SerializeField] private Button toP;
    [SerializeField] private Button toC;
    [SerializeField] private Button pauseonC;
    [SerializeField] private Button pauseonP;
    [SerializeField] private Button continueonC;
    [SerializeField] private Button okonC;
    [SerializeField] private Button continueonP;
    [SerializeField] private Button okonP;
    [SerializeField] private Button toPonmain;
    [SerializeField] private Button toConmain;
    [SerializeField] private Button navoffbutton;
    [SerializeField] private Button navonbutton;
    [SerializeField] private Button r1offonr1;
    [SerializeField] private Button r1offoncontrol;
    [SerializeField] GameObject admintoggle;
    [SerializeField] GameObject oyatoggle;
    [SerializeField] GameObject r1toggle;
    [SerializeField] private GameObject r1panel;
    [SerializeField] private GameObject r1controlpanel;
    [SerializeField] private GameObject cmdpanel;
    [SerializeField] private Button allstopbutton;
    [SerializeField] private Graphic backgroundGraphic;
    [SerializeField] private Color okColor, nullColor;
    private readonly Vector2 _on = new(7f, -1.3f);
	private readonly Vector2 _off = new(20f, -1.3f);

    private bool is_oyapanel = false;
    private bool is_r1panel = false;
    private bool is_mainpanel = true;
    private bool is_navon = true;
    private bool is_admin;
    private bool is_oyaari;
    private bool is_r1ari;
    [System.NonSerialized] public bool SubPause = false;
    private Domaintest domaintest;
    private Color backgroundColor {
	    set{
            if (backgroundGraphic == null) return;
			backgroundGraphic.color = value;
        }
	}

 
 
    //呼び出し時に実行される関数
    void Start () {
        domaintest = GameObject.Find("R1Ope").GetComponent<Domaintest>();
        toP.onClick.AddListener(stopchild);
        toC.onClick.AddListener(childOn);
        toPonmain.onClick.AddListener(stopchild);
        toConmain.onClick.AddListener(childmainOn);
        //pauseonC.onClick.AddListener(childmainOn);
        //pauseonP.onClick.AddListener(parentmainOn);
        continueonC.onClick.AddListener(childOn);
        okonC.onClick.AddListener(childOn);
        continueonP.onClick.AddListener(parentOn);
        okonP.onClick.AddListener(parentOn);
        //allstopbutton.onClick.AddListener(allstop);

        navoffbutton.onClick.AddListener(r1controlOn);
        navonbutton.onClick.AddListener(r1On);
        r1offonr1.onClick.AddListener(r1Off);
        r1offoncontrol.onClick.AddListener(r1Off);
        childmainOn();
        r1Off();
        if(PlayerPrefs.GetString("domain")=="0"){
            oyatoggle.GetComponent<IOSButton>().SetOn();
            is_oyaari = oyatoggle.GetComponent<IOSButton>().GetisOn();
            stopchild();
        }else if(PlayerPrefs.GetString("domain")=="4"){
            r1toggle.GetComponent<IOSButton>().SetOn();
            is_r1ari = r1toggle.GetComponent<IOSButton>().GetisOn();
            stopchild();
        }
        if(PlayerPrefs.GetInt("kengen")==1){
            oyatoggle.GetComponent<IOSButton>().SetOn();
            is_oyaari = oyatoggle.GetComponent<IOSButton>().GetisOn();
        }else if(PlayerPrefs.GetInt("kengen")==2){
            r1toggle.GetComponent<IOSButton>().SetOn();
            is_r1ari = r1toggle.GetComponent<IOSButton>().GetisOn();
        }
    }
    void Update()
    {
        if(is_oyaari && r1toggle.GetComponent<IOSButton>().GetisOn())oyatoggle.GetComponent<IOSButton>().SetOff();
        if(is_r1ari && oyatoggle.GetComponent<IOSButton>().GetisOn())r1toggle.GetComponent<IOSButton>().SetOff();
        admintoggle.GetComponent<IOSButton>().Set();
        r1toggle.GetComponent<IOSButton>().Set();
        oyatoggle.GetComponent<IOSButton>().Set();
        is_admin = admintoggle.GetComponent<IOSButton>().GetisOn();
        is_oyaari = oyatoggle.GetComponent<IOSButton>().GetisOn();
        is_r1ari = r1toggle.GetComponent<IOSButton>().GetisOn();
        if(is_oyaari)PlayerPrefs.SetInt("kengen",1);
        else if(is_r1ari)PlayerPrefs.SetInt("kengen",2);
        else PlayerPrefs.SetInt("kengen",0);
        PlayerPrefs.Save();
        if(!is_oyaari & is_oyapanel & is_mainpanel){
            childmainOn();
        }else if(!is_oyaari & is_oyapanel & !is_mainpanel){
            childOn();
        }
        if(!is_r1ari && is_r1panel)r1Off();
        Transform myt = cmdpanel.transform;
        if(is_mainpanel && !is_r1panel){
            myt.position = _on;
        }else{
            myt.position = _off;
        }
        if(is_admin){
            backgroundColor = okColor;
        }else{
            backgroundColor = nullColor;
        }
        if(SubPause & is_oyapanel){
            parentmainOn();
            SubPause = false;
        }else if(SubPause){
            childmainOn();
            SubPause = false;
        }
    }

    void childOn(){
        is_oyapanel = false;
        is_mainpanel = false;
        childPanel.SetActive(true);
        parentPanel.SetActive(false);
        childMainPanel.SetActive(false);
        parentMainPanel.SetActive(false);
    }
    void parentOn(){
        if(is_oyaari){
            is_oyapanel = true;
            is_mainpanel = false;
            childPanel.SetActive(false);
            parentPanel.SetActive(true);
            childMainPanel.SetActive(false);
            parentMainPanel.SetActive(false);
        }
    }
    void childmainOn(){
        is_oyapanel = false;
        is_mainpanel = true;
        childPanel.SetActive(false);
        parentPanel.SetActive(false);
        childMainPanel.SetActive(true);
        parentMainPanel.SetActive(false);
    }
    void parentmainOn(){
        if(is_oyaari){
            is_oyapanel = true;
            is_mainpanel = true;
            childPanel.SetActive(false);
            parentPanel.SetActive(false);
            childMainPanel.SetActive(false);
            parentMainPanel.SetActive(true);
        }
    }
    void stopchild(){
        if(is_r1ari && is_navon){
            domaintest.stmsgs.Enqueue("n on");
            r1On();
        }else if(is_r1ari){
            domaintest.stmsgs.Enqueue("n off");
            r1controlOn();
        }else if(is_mainpanel){
            parentmainOn();
        }else{
            parentOn();
        }
    }
    void r1On(){
        is_r1panel = true;
        is_navon = true;
        r1panel.SetActive(true);
        r1controlpanel.SetActive(false);
    }
    void r1controlOn(){
        is_r1panel = true;
        is_navon = false;
        r1panel.SetActive(false);
        r1controlpanel.SetActive(true);
    }
    void r1Off(){
        is_r1panel = false;
        r1panel.SetActive(false);
        r1controlpanel.SetActive(false);
    }
    void allstop(){
        if(is_oyapanel & is_admin){
            parentmainOn();
        }else if(is_admin){
            childmainOn();
        }
    }
    public bool Getisoya(){
        return is_oyapanel;
    }
    public bool Getismain(){
        return is_mainpanel;
    }
    public bool Getisadmin(){
        return is_admin;
    }
    public bool Getisr1(){
        return is_r1panel;
    }
    public bool Getisnav(){
        return is_navon;
    }
}
