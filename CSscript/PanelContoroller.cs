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
    [SerializeField] private Button continueonP;
    [SerializeField] private Button toPonmain;
    [SerializeField] private Button toConmain;
    [SerializeField] GameObject admintoggle;
    [SerializeField] GameObject oyatoggle;
    [SerializeField] private GameObject cmdpanel;
    [SerializeField] private Button allstopbutton;
    [SerializeField] private Graphic backgroundGraphic;
    [SerializeField] private Color okColor, nullColor;
    private readonly Vector2 _on = new(7f, -1.3f);
	private readonly Vector2 _off = new(20f, -1.3f);

    private bool is_oyapanel = false;
    private bool is_mainpanel = true;
    private bool is_admin;
    private bool is_oyaari;
    [System.NonSerialized] public bool SubPause = false;
    private Color backgroundColor {
	    set{
            if (backgroundGraphic == null) return;
			backgroundGraphic.color = value;
        }
	}

 
 
    //呼び出し時に実行される関数
    void Start () {
        toP.onClick.AddListener(parentOn);
        toC.onClick.AddListener(childOn);
        toPonmain.onClick.AddListener(parentmainOn);
        toConmain.onClick.AddListener(childmainOn);
        //pauseonC.onClick.AddListener(childmainOn);
        //pauseonP.onClick.AddListener(parentmainOn);
        continueonC.onClick.AddListener(childOn);
        continueonP.onClick.AddListener(parentOn);
        allstopbutton.onClick.AddListener(allstop);
        childmainOn();
    }
    void Update()
    {
        is_admin = admintoggle.GetComponent<IOSButton>().GetisOn();
        is_oyaari = oyatoggle.GetComponent<IOSButton>().GetisOn();
        if(!is_oyaari & is_oyapanel & is_mainpanel){
            childmainOn();
        }else if(!is_oyaari & is_oyapanel & !is_mainpanel){
            childOn();
        }
        Transform myt = cmdpanel.transform;
        if(is_mainpanel){
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
}
