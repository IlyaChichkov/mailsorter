﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoals : MonoBehaviour
{
    public static LevelGoals _levelGoals;
    public List<Goal> goals = new List<Goal>();

    public GoalsView goalsView;

    void Start()
    {
        _levelGoals = this;
        
        CheckGoals();
        SetGoalsText();
    }


    // изменяем значение цели
    public static void ChangeGoalValue(GoalType type, bool setValue, float amount) // если setValue = false, то значение не устанавливается, а прибавляется
    {
        Goal goal = GetGoalWithType(type);

        if (goal != null)
        {
            if(setValue){
                goal.currentValue = amount;
            }else{
                goal.currentValue += amount;
            }
            _levelGoals.SetGoalsText();
            _levelGoals.CheckGoals();
        }
    }

    // находим цель с нужным типом задания (если такая есть)
    private static Goal GetGoalWithType(GoalType type)
    {
        foreach (Goal goal in _levelGoals.goals)
        {
            if (goal.goal_type == type)
            {
                return goal;
            }
        }
        return null;
    }

    // прописываем текст заданий в таблице
    private void SetGoalsText()
    {
        int goalNum = 0;
        foreach (Goal goal in goals)
        {
            switch (goal.goal_type)
            {
                case GoalType.all_mail_delivered:
                    goalsView.goalsText[goalNum].text = $"Deliver mail ({goal.currentValue}/{goal.requiredValue})";
                    break;
                case GoalType.days_left:
                    goalsView.goalsText[goalNum].text = $"Deliver mail for ({goal.requiredValue}) days";
                    break;
                case GoalType.get_money:
                    goalsView.goalsText[goalNum].text = $"Get some money in amount of {goal.requiredValue}";
                    break;
            }

            goalNum++;
        }
    }

    // проверяем готовность задания
    public void CheckGoals()
    {
        int goalNum = 0;
        foreach (Goal goal in goals)
        {
            if (goal.IsGoalComplete())
            {
                goal.isActive = true;
                goalsView.goalsToggels[goalNum].isOn = true;
            }
            goalNum++;
        }
    }
}
