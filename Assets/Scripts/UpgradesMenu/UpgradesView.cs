using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesView : MonoBehaviour
{
    public GameObject UpgradesCanvas;
    public void SetUpgradesCanvas(){
        UpgradesCanvas.SetActive(!UpgradesCanvas.activeSelf);
    }
}
