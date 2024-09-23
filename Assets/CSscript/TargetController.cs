using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;

public class TargetController : MonoBehaviour
{
    [SerializeField] private Button c1button;
    [SerializeField] private Button c2button;
    [SerializeField] private Button c3button;
    [SerializeField] private GameObject c1image;
    [SerializeField] private GameObject c2image;
    [SerializeField] private GameObject c3image;
    [SerializeField] GameObject UIOpe;
    [SerializeField] TMP_Text tmp;
    [SerializeField] TMP_Text buttontmp;
    [SerializeField] TMP_Text buttonmaintmp;
    [SerializeField] private Graphic backgroundGraphic;
	[SerializeField] private Color childColor, parentColor;
    private int target = 1;
    private bool isOya = false;
    private bool isr1 = false;
    private string childtarget = "c1";
    private Color targetcolor {
	    set{
            if (backgroundGraphic == null) return;
			backgroundGraphic.color = value;
        }
	}
    // Start is called before the first frame update
    void Start()
    {
        c1button.onClick.AddListener(() => changetarget(1));
        c2button.onClick.AddListener(() => changetarget(2));
        c3button.onClick.AddListener(() => changetarget(3));
        if(PlayerPrefs.GetString("domain")=="2")changetarget(2);
        else if(PlayerPrefs.GetString("domain")=="3")changetarget(3);
        else changetarget(1);
    }
    void Update(){
        isOya = UIOpe.GetComponent<PanelContoroller>().Getisoya();
        isr1 = UIOpe.GetComponent<PanelContoroller>().Getisr1();
        if(isr1){
            targetcolor = parentColor;
            tmp.text = "R1";
        }else if (isOya){
            targetcolor = parentColor;
            tmp.text = "P1";
        }else{
            targetcolor = childColor;
            tmp.text  = "C"+target;
            buttontmp.text = "C"+target;
            buttonmaintmp.text = "C"+target;
        }
    }
    void changetarget(int target_num){
        target = target_num;
        if(target_num == 1){
            c1image.SetActive(true);
            c2image.SetActive(false);
            c3image.SetActive(false);
        }else if(target_num == 2){
            c1image.SetActive(false);
            c2image.SetActive(true);
            c3image.SetActive(false);
        }else if(target_num == 3){
            c1image.SetActive(false);
            c2image.SetActive(false);
            c3image.SetActive(true);
        }
    }
    public string GettargetSt(){
        if(target == 1){
            childtarget = "C1";
        }else if(target == 2){
            childtarget = "C2";
        }else if(target == 3){
            childtarget = "C3";
        }
        return childtarget;
    }
    public int GettargetNum(){
        return target;
    }
}
