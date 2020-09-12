using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailMarker : MonoBehaviour
{
    public enum markerColors {green, blue, red, purple, yellow};
    public markerColors markerColor;

    void Start()
    {
        switch(markerColor){
            case markerColors.green:
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
            break;
            
            case markerColors.blue:
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.blue;
            break;
            case markerColors.red:
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
            break;
            case markerColors.purple:
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.2f, 1, 1);
            break;
            case markerColors.yellow:
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.yellow;
            break;
        }
    }
}
