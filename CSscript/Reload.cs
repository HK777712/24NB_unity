using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Kogane;
public class Reload : MonoBehaviour
{
    public Button button;
    void Start(){
        button.onClick.AddListener(ReloadButton);
    }
    void ReloadButton(){
        ApplicationRestarter.Restart();
    }
}
