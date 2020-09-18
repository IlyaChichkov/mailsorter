using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Goal
{
    public bool isActive = false;
    public GoalType goal_type;
    public float requiredValue = 0;
    public float currentValue = 0;

    public bool IsGoalComplete(){
        return (currentValue >= requiredValue);
    }
}

public enum GoalType { all_mail_delivered, days_left, get_money };
