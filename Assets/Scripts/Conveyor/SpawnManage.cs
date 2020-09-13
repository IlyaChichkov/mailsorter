using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManage : MonoBehaviour
{
    public bool isSpawning = true;
    [Header("Spawn Settings")]

    public float mailSpeed = 1f;

    public float mailSpawnPeriod = 0.5f;

    [Space]
    public Transform spawnPosition;

    public GameObject mail;
    public List<Sprite> mailVariations = new List<Sprite>();

    void Start()
    {
        StartCoroutine(SpawnMailTimer());
    }

    private IEnumerator SpawnMailTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(mailSpawnPeriod);

            if(isSpawning){
            SpawnMail();
            }
        }
    }

    public void SpawnMail()
    {
        // создаем объект
        GameObject mailCopy = Instantiate(mail);
        // перемещаем на позицию спавна
        mailCopy.transform.position = spawnPosition.position;
        // задаем случайный поворот
        mailCopy.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        // задаем случайный скин
        mailCopy.GetComponent<SpriteRenderer>().sprite = mailVariations[Random.Range(0, mailVariations.Count)];
        // назначаем точкой пути точку спавна
        mailCopy.GetComponent<MailboxMovement>().movementPoints.Add(spawnPosition);
        // ставим скорость передвижения
        mailCopy.GetComponent<MailboxMovement>().MoveSpeed = mailSpeed;
        // задаем возможный цвет посылки
        var levelColors = transform.parent.gameObject.GetComponent<AllPointsParent>().avaliableLevelPointsColors;
        var mailMarkerColor = levelColors[Random.Range(0, levelColors.Count)];
        System.Enum.TryParse(mailMarkerColor, out mailCopy.GetComponent<MailMarker>().markerColor);
        // задаем награды за посылку
        mailCopy.GetComponent<MailRewards>().SetMailSpecificReward();
    }
}
