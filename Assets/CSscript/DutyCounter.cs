using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;

public class DutyCounter : MonoBehaviour
{
    [SerializeField] TMP_Text tmp;
    [SerializeField] Button down;
    [SerializeField] Button up;
    [SerializeField] Button reset;
    private int n = 0;
    // Start is called before the first frame update
    void Start()
    {
        down.onClick.AddListener(() => ndown());
        up.onClick.AddListener(() => nup());
        reset.onClick.AddListener(() => nreset());
    }
    void nreset(){
        n = 0;
    }
    void nup(){
        n+=1;
    }
    void ndown(){
        n-=1;
    }
    // Update is called once per frame
    void Update()
    {
        tmp.text = n.ToString();
    }
}
