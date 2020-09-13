using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour
{
    private static PlayerResources _resourcesScript;
    private int Money = 0;
    private int ResearchPoints = 0;
    public Text moneyText;
    public Text rpText;

    void Start()
    {
        _resourcesScript = this;

        moneyText.text = Money.ToString();
        rpText.text = ResearchPoints.ToString();
    }

    private static PlayerResources resourcesScript{
        get{
            if(_resourcesScript == null){
                _resourcesScript = GameObject.Find("Economy").AddComponent<PlayerResources>();
            }

        return _resourcesScript;
        }

        set{
            _resourcesScript = value;
        }
    }
    // изменение Money
    public static void ChangeMoney(int value){
        resourcesScript.Money += value;
        resourcesScript.moneyText.text = resourcesScript.Money.ToString();
        
        if(resourcesScript.Money < -15){ // БАНКРОТ
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }

    // изменение ResearchPoints
    public static void ChangeRP(int value){
        resourcesScript.ResearchPoints += value;
        resourcesScript.rpText.text = resourcesScript.ResearchPoints.ToString();
    }
}
