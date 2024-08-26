using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IOSButton : MonoBehaviour
{
    private readonly Vector2 _min = new(0, 0.5f);
	private readonly Vector2 _max = new(1, 0.5f);
    [SerializeField] private Graphic backgroundGraphic;
	[SerializeField] private Color onColor, offColor;
	[SerializeField] private RectTransform tipRect;
    private bool isOn;
    public Button button;
    private Color backgroundColor {
	    set{
            if (backgroundGraphic == null) return;
			backgroundGraphic.color = value;
        }
	}
    void Start()
    {
        button.onClick.AddListener(() => OnChange());
        if (isOn){
            SetOn();
        }else{
            SetOff();
        }
    }
    void OnChange(){
        isOn = !isOn;
        if (isOn){
            SetOn();
        }else{
            SetOff();
        }
    }
    private void SetOn() {
		SetAnchors(_max);
		backgroundColor = onColor;
	}
	private void SetOff() {
		SetAnchors(_min);
		backgroundColor = offColor;
	}
    private void SetAnchors(Vector2 anchor) {
		tipRect.anchorMin = anchor;
		tipRect.anchorMax = anchor;
		tipRect.pivot = anchor;
	}
    public bool GetisOn(){
        return isOn;
    }
}
