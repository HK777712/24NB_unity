using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSideScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int width = Screen.currentResolution.width;
        int height = Screen.currentResolution.height;
        RectTransform rect = this.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(width,height);
    }
}
