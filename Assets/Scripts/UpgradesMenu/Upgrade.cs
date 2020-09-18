using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrade
{
    public UpgradeType upgradeType;
    public string title = "";
    public string description = "";
    public Sprite image;
    public int researchCost = 0;
    public int moneyCost = 0;
    public int upgradeStagesAmount = 1;
    public int currentStage = 0;
    public float upgradeValue = 0;
}

public enum UpgradeType {conveyorSpeed, autoSort}
