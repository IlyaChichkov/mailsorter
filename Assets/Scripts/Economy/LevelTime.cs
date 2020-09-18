using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTime : MonoBehaviour
{
    public Text day;

    private string dayText = "Day";
    private string nightText = "Night";
    private int dayNum = 1;

    private int DayCircle = 1; // цикл дня состоит из одного дня и одной ночи, переменная нужна чтобы их чередовать

    public Image clockImage;

    public float oneDayTime = 10f; // время одного дня в (с)
    private float currentTime = 0f;

    public SpawnManage spawnManager;

    void Start()
    {
        spawnManager = GameObject.Find("Spawn").GetComponent<SpawnManage>();
        day.text = dayText + " " + dayNum;
    }

    void Update()
    {
        if(currentTime < oneDayTime){
            currentTime += Time.deltaTime;
            clockImage.fillAmount = currentTime / oneDayTime;
        }
        else{
            currentTime = 0;

            if(DayCircle == 0){
            DayCircle = 1;
            dayNum++;
            day.text = dayText + " " + dayNum;
            spawnManager.isSpawning = true;
            // Задание по кол-ву дней
            LevelGoals.ChangeGoalValue(GoalType.days_left, true, dayNum);
            }else{
            DayCircle = 0;
            day.text = nightText + " " + dayNum;
            spawnManager.isSpawning = false;
            }
        }
    }
}
