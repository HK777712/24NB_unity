using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ledsetr1 : MonoBehaviour
{
    private Domaintest pubcon;
    [SerializeField] GameObject speedtoggle;
    private bool ison;
    // Start is called before the first frame update
    void Start()
    {
        pubcon = GameObject.Find("R1Ope").GetComponent<Domaintest>();
        
    }
    // Update is called once per frame
    void Update()
    {
        speedtoggle.GetComponent<IOSButton>().Set();
        if(ison!=speedtoggle.GetComponent<IOSButton>().GetisOn()){
            ison = speedtoggle.GetComponent<IOSButton>().GetisOn();
            if(ison){
                pubcon.stmsgs.Enqueue("team red");
            }else{
                pubcon.stmsgs.Enqueue("team blue");
            }
        }
    }
}
