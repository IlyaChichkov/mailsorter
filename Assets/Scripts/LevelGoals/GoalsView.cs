using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalsView : MonoBehaviour
{
    public GameObject GoalsTables;

    public List<Text> goalsText;

    public List<Toggle> goalsToggels;

    public void ActiveGoalsTables(){
        GoalsTables.SetActive(!GoalsTables.active);
    }
}
