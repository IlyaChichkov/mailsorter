using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvent : MonoBehaviour
{
    public enum eventType {endPoint, destructor};
    public eventType type;

    public enum pointColors {green, blue, red, purple, yellow};
    public pointColors color;

    private GameObject triggerObject;

    void Start()
    {
        transform.parent.gameObject.GetComponent<AllPointsParent>().avaliableLevelPointsColors.Add(color.ToString());
    }
    public void StartEvent(GameObject triggerObject){
        this.triggerObject = triggerObject;
        // определяем тип события
        switch(type){
            case eventType.endPoint:
                MailEndPoint();
            break;
        }
    }

    private void MailEndPoint(){
        if((int)triggerObject.GetComponent<MailMarker>().markerColor == (int)color){
            Debug.Log("Right delivery");
        }else{
            Debug.Log("Wrong delivery");
        }
        triggerObject.GetComponent<Animator>().SetBool("Destroyed", true);
    }
}