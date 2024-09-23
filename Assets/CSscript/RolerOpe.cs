using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RolerOpe : MonoBehaviour
{
    private PubConCutom pubcon;
    [SerializeField] GameObject speedtoggle;
    [SerializeField] Button okbuttonoya;
    [SerializeField] Button start;
    [SerializeField] Button stop;
    private bool ison;
    // Start is called before the first frame update
    void Start()
    {
        pubcon = GameObject.Find("Pubcontoroller").GetComponent<PubConCutom>();
        okbuttonoya.onClick.AddListener(() => OnChange());
        start.onClick.AddListener(() => Onstart());
        stop.onClick.AddListener(() => Onstop());
    }
    void Onstart(){
        speedtoggle.GetComponent<IOSButton>().SetOn();
    }
    void Onstop(){
        speedtoggle.GetComponent<IOSButton>().SetOff();
    }

    // Update is called once per frame
    void OnChange(){
        speedtoggle.GetComponent<IOSButton>().SetOn();
    }
    void Update()
    {
        speedtoggle.GetComponent<IOSButton>().Set();
        if(ison!=speedtoggle.GetComponent<IOSButton>().GetisOn()){
            ison = speedtoggle.GetComponent<IOSButton>().GetisOn();
            if(ison){
                pubcon.queue.Enqueue("r on");
            }else{
                pubcon.queue.Enqueue("r off");
            }
        }
    }
}
