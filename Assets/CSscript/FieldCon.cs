using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FieldCon : MonoBehaviour
{
    public TMP_InputField inputField;
    private PubCon pubcon;
    void Start(){
        pubcon = GameObject.Find("Pubcontoroller").GetComponent<PubCon>();
    }
    public void EnterPressed()
    {
        if(inputField.text != ""){
            pubcon.queue.Enqueue(inputField.text);
            inputField.text = "";
        }
    }
}
