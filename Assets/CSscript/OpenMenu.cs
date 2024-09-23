using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;           //サブカメラ格納用 
    [SerializeField] private Button menubutton;
    public Image buttonimage;
    public Sprite _menu;
    public Sprite _batu;

    private bool is_menu = false;

 
 
    //呼び出し時に実行される関数
    void Start () {
        menubutton.onClick.AddListener(changemenu);
    }
    
 
    //単位時間ごとに実行される関数
    void Update () {
        //スペースキーが押されている間、サブカメラをアクティブにする
        
        if(is_menu){
            //メインカメラをアクティブに設定
            menuPanel.SetActive(true);
            buttonimage.sprite = _batu;
        }else{
            //サブカメラをアクティブに設定
            menuPanel.SetActive(false);
            buttonimage.sprite = _menu;
        }
    }

    void changemenu(){
        is_menu = !is_menu;
    }
}
