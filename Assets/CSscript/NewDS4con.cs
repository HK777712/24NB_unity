using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
[System.Serializable] // <- これが大事。忘れずに
public class NewDs4button {
    public ButtonList ds4button;
    public Button button;
    public PanelList panel;
}
public class NewDS4con : MonoBehaviour
{
    [SerializeField] GameObject uiope;
    [SerializeField] List<NewDs4button> ds4data;
    private GameInputs _gameInputs;
    private bool is_oya;
    private bool is_main;
    private bool is_r1;
    private bool is_nav;
    private PanelList nowpanel;
    private Vector2 _leftdsjoy;
    private Vector2 _rightdsjoy;
    private float _r2float;
    private bool osareta=false;
    private bool notconnected = false;
    private bool connected = false;
    private bool sankakuosu;
    private void Awake(){
        StartCoroutine(connectcheck());
        _gameInputs = new GameInputs();

        // Actionイベント登録
        _gameInputs.Player.Move.started += OnMove;
        _gameInputs.Player.Move.performed += OnMove;
        _gameInputs.Player.Move.canceled += OnMove;
        _gameInputs.Player.Dir.started += OnDir;
        _gameInputs.Player.Dir.performed += OnDir;
        _gameInputs.Player.Dir.canceled += OnDir;
        _gameInputs.Player.Maru.performed += OnMaru;
        _gameInputs.Player.Batu.performed += OnBatu;
        _gameInputs.Player.Sikaku.performed += OnSikaku;
        _gameInputs.Player.Sankaku.performed += OnSankaku;
        _gameInputs.Player.Up.performed += OnUp;
        _gameInputs.Player.Down.performed += OnDown;
        _gameInputs.Player.Left.performed += OnLeft;
        _gameInputs.Player.Right.performed += OnRight;
        _gameInputs.Player.L1.performed += OnL1;
        _gameInputs.Player.L2.performed += OnL2;
        _gameInputs.Player.R1.performed += OnR1;
        _gameInputs.Player.R2.performed += OnR2;
        _gameInputs.Player.Sankaku.started+= OnSankakustart;
        _gameInputs.Player.Sankaku.canceled+= OnSankakustop;

        _gameInputs.Enable();
    }
    private void OnMove(InputAction.CallbackContext context){
        osareta = true;
        _leftdsjoy = context.ReadValue<Vector2>();
    }
    private void OnMovecan(InputAction.CallbackContext context){
        osareta = true;
    }
    private void OnDir(InputAction.CallbackContext context){
        osareta = true;
        _rightdsjoy = context.ReadValue<Vector2>();
    }
    private void Update(){
        is_oya = uiope.GetComponent<PanelContoroller>().Getisoya();
        is_main = uiope.GetComponent<PanelContoroller>().Getismain();
        is_r1 = uiope.GetComponent<PanelContoroller>().Getisr1();
        is_nav = uiope.GetComponent<PanelContoroller>().Getisnav();
        if(is_r1 && is_nav){
            nowpanel = PanelList.R1;
        }else if(is_r1){
            nowpanel = PanelList.R1con;
        }else if (is_main && is_oya){
            nowpanel = PanelList.Oyamain;
        }else if(is_main && !is_oya){
            nowpanel = PanelList.Komain;
        }else if(!is_main && is_oya){
            nowpanel = PanelList.Oyacon;
        }else{
            nowpanel = PanelList.Kocon;
        }
    }

    private void OnDestroy(){
        _gameInputs?.Dispose();
    }
    private void OnSankakustart(InputAction.CallbackContext context){
        sankakuosu = true;
    }
    private void OnSankakustop(InputAction.CallbackContext context){
        sankakuosu = false;
    }
    private void OnMaru(InputAction.CallbackContext context){Osu(ButtonList.Maru);}
    private void OnBatu(InputAction.CallbackContext context){Osu(ButtonList.Batu);}
    private void OnSikaku(InputAction.CallbackContext context){Osu(ButtonList.Sikaku);}
    private void OnSankaku(InputAction.CallbackContext context){Osu(ButtonList.Sankaku);}
    private void OnUp(InputAction.CallbackContext context){Osu(ButtonList.Up);}
    private void OnDown(InputAction.CallbackContext context){Osu(ButtonList.Down);}
    private void OnLeft(InputAction.CallbackContext context){Osu(ButtonList.Left);}
    private void OnRight(InputAction.CallbackContext context){Osu(ButtonList.Right);}
    private void OnL1(InputAction.CallbackContext context){Osu(ButtonList.L1);}
    private void OnL2(InputAction.CallbackContext context){Osu(ButtonList.L2);}
    private void OnR1(InputAction.CallbackContext context){Osu(ButtonList.R1);}
    private void OnR2(InputAction.CallbackContext context){Osu(ButtonList.R2);}
    private void Osu(ButtonList OsuButton){
        osareta=true;
        List<NewDs4button> result = ds4data.FindAll(m => m.ds4button == OsuButton);
        for(int count = 0;count < result.Count;count++){
            if(result[count].panel == nowpanel || result[count].panel == PanelList.CMD){
                Debug.Log("New:"+result[count].ds4button.ToString());
                result[count].button.onClick.Invoke();
            }
        }
    }
    public bool Getsankaku(){
        return sankakuosu;
    }
    public Vector2 Getleftjoy(){
        return _leftdsjoy;
    }
    public Vector2 Getrightjoy(){
        return _rightdsjoy;
    }
    public float Getr2float(){
        return _r2float;
    }
    IEnumerator connectcheck(){
        while(true){
                
                yield return new WaitForFixedUpdate();
            var game = Gamepad.all;
            if(game.Count==0){
                _leftdsjoy = new Vector2(0,0);
                _rightdsjoy = new Vector2(0,0);
            } 
        }
    }
}
public enum ButtonList
{
    Sikaku,Batu,Maru,Sankaku,L1,L2,R1,R2,Lo,Ro,Up,Down,Right,Left
}
public enum PanelList
{
    Oyacon,Oyamain,Kocon,Komain,R1,R1con,CMD,Null
}