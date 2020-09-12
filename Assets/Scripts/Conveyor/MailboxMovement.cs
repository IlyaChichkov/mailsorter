using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MailboxMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    public float MoveSpeed = 4f;
    public float SnapPointValue = 0.04f;

    public List<Transform> movementPoints = new List<Transform>();

    void Update()
    {
        // если есть точки маршрута
        if (movementPoints.Count > 0)
        {
            int axisX = 0;
            int axisY = 0;

            // перемещение
            // если Х меньше чем Х-точки
            if (transform.position.x < movementPoints[0].position.x)
            {
                // если мы близко к Х-точки, ставим Х = Х-точки
                if (transform.position.x + SnapPointValue > movementPoints[0].position.x)
                {
                    transform.position = new Vector2(movementPoints[0].position.x, transform.position.y);
                }
                else
                {
                    axisX = 1;
                }
            }
            if (transform.position.x > movementPoints[0].position.x)
            {
                if (transform.position.x - SnapPointValue < movementPoints[0].position.x)
                {
                    transform.position = new Vector2(movementPoints[0].position.x, transform.position.y);
                }
                else
                {
                    axisX = -1;
                }
            }
            if (transform.position.y < movementPoints[0].position.y)
            {
                if (transform.position.y + SnapPointValue > movementPoints[0].position.y)
                {
                    transform.position = new Vector2(transform.position.x, movementPoints[0].position.y);
                }
                else
                {
                    axisY = 1;
                }
            }
            if (transform.position.y > movementPoints[0].position.y)
            {
                if (transform.position.y - SnapPointValue < movementPoints[0].position.y)
                {
                    transform.position = new Vector2(transform.position.x, movementPoints[0].position.y);
                }
                else
                {
                    axisY = -1;
                }
            }

            // если цель достигнута
            if (transform.position == movementPoints[0].position)
            {
                axisX = 0;
                axisY = 0;
                // если у точки есть событие
                if (movementPoints[0].GetComponent<PointEvent>())
                {
                    movementPoints[0].GetComponent<PointEvent>().StartEvent(this.gameObject);
                }

                // получаем имеющиеся новые точки
                var pointConnection = movementPoints[0].GetComponent<PointConnections>().GetConnection();

                // добавляем новые точки, если есть
                if (pointConnection != null)
                {
                    movementPoints.Add(pointConnection);
                }

                // удаляем достигнутую точку
                movementPoints.RemoveAt(0);
            }else{
                transform.position = new Vector3(transform.position.x + axisX * MoveSpeed * Time.deltaTime, transform.position.y + axisY * MoveSpeed * Time.deltaTime, transform.position.z);
            }
        }
    }
}
