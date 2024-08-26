using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
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
    private PanelList nowpanel;
    private Vector2 _leftdsjoy;
    private Vector2 _rightdsjoy;
    private void Awake(){
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

        _gameInputs.Enable();
    }
    private void OnMove(InputAction.CallbackContext context){
        _leftdsjoy = context.ReadValue<Vector2>();
    }
    private void OnDir(InputAction.CallbackContext context){
        _rightdsjoy = context.ReadValue<Vector2>();
    }
    private void Update(){
        is_oya = uiope.GetComponent<PanelContoroller>().Getisoya();
        is_main = uiope.GetComponent<PanelContoroller>().Getismain();
        if (is_main && is_oya){
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
        List<NewDs4button> result = ds4data.FindAll(m => m.ds4button == OsuButton);
        for(int count = 0;count < result.Count;count++){
            if(result[count].panel == nowpanel || result[count].panel == PanelList.CMD){
                Debug.Log("New:"+result[count].ds4button.ToString());
                result[count].button.onClick.Invoke();
            }
        }
    }
    public Vector2 Getleftjoy(){
        return _leftdsjoy;
    }
    public Vector2 Getrightjoy(){
        return _rightdsjoy;
    }
}
public enum ButtonList
{
    Sikaku,Batu,Maru,Sankaku,L1,L2,R1,R2,Lo,Ro,Up,Down,Right,Left
}
public enum PanelList
{
    Oyacon,Oyamain,Kocon,Komain,CMD,Null
}