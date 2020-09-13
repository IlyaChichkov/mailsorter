using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailRewards : MonoBehaviour
{
    public int moneyReward;
    public int researchPointReward;

    public void SetMailSpecificReward(){
        moneyReward = Random.Range(6, 50);

        if(Random.Range(0, 100) > 70){
            researchPointReward = Random.Range(1, 6);
        }
    }
}
