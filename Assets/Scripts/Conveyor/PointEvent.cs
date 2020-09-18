using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvent : MonoBehaviour
{
    public enum eventType { endPoint, bombConservation };
    public eventType type;

    public enum pointColors { green, blue, red, purple, yellow };
    public pointColors color;

    private GameObject triggerObject;

    void Start()
    {
        transform.parent.gameObject.GetComponent<AllPointsParent>().avaliableLevelPointsColors.Add(color.ToString());
    }
    public void StartEvent(GameObject triggerObject)
    {
        this.triggerObject = triggerObject;
        // определяем тип события
        switch (type)
        {
            case eventType.endPoint:
                MailEndPoint();
                break;
            case eventType.bombConservation:
                MailEndPoint();
                break;
        }
    }

    private void BombConservation()
    {
        if (triggerObject.tag == "Bomb")
        {
            Debug.Log("Bomb conserved");
            triggerObject.GetComponent<BombDestroy>().DestroyBomb();
        }
        else
        {
            Debug.Log("Mail destroyed");
            PlayerResources.ChangeMoney(-triggerObject.GetComponent<MailRewards>().moneyReward);

            triggerObject.GetComponent<Animator>().SetBool("Destroyed", true);
        }
    }

    private void MailEndPoint()
    {
        if (triggerObject.tag == "Bomb")
        {
            Debug.Log("Bomb detonated");
            triggerObject.GetComponent<BombDestroy>().DestroyBomb();
        }
        else
        {

            if ((int)triggerObject.GetComponent<MailMarker>().markerColor == (int)color)
            {
                Debug.Log("Right delivery");
                PlayerResources.ChangeMoney(triggerObject.GetComponent<MailRewards>().moneyReward);
                PlayerResources.ChangeRP(triggerObject.GetComponent<MailRewards>().researchPointReward);

                LevelScore.mailDelivered++;
                LevelGoals.ChangeGoalValue(GoalType.all_mail_delivered, false, 1);
            }
            else
            {
                Debug.Log("Wrong delivery");
                PlayerResources.ChangeMoney(-triggerObject.GetComponent<MailRewards>().moneyReward / 2);
            }
            triggerObject.GetComponent<Animator>().SetBool("Destroyed", true);
        }
    }
}