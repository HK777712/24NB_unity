using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class YazirusiOpe : MonoBehaviour
{
    public List<Button> c2buttons= new List<Button>();
    public List<Button> c3buttons= new List<Button>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0;i<c2buttons.Count;i++){
            int oku = i;
            c2buttons[i].onClick.AddListener(() => C2osu(oku));
            GameObject ya = c2buttons[i].transform.Find("point").gameObject;
            ya.SetActive(false);
        }
        for (int i = 0;i<c3buttons.Count;i++){
            int oku = i;
            c3buttons[i].onClick.AddListener(() => C3osu(oku));
            GameObject ya = c3buttons[i].transform.Find("point").gameObject;
            ya.SetActive(false);
        }
    }
    void C2osu(int num){
        for (int i = 0;i<c2buttons.Count;i++){
            GameObject ya = c2buttons[i].transform.Find("point").gameObject;
            if(num==i)ya.SetActive(true);
            else ya.SetActive(false);
        }
    }
    void C3osu(int num){
        for (int i = 0;i<c3buttons.Count;i++){
            GameObject ya = c3buttons[i].transform.Find("point").gameObject;
            if(i==num){
                ya.SetActive(true);
                //Debug.Log("kita");
            }else{
                ya.SetActive(false);
                //Debug.Log("konai"+i+"num;"+num);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
