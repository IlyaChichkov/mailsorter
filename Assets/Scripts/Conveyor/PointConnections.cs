using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointConnections : MonoBehaviour
{
    public Transform[] connections = new Transform[4];
    public Transform topConnection;
    public Transform downConnection;
    public Transform leftConnection;
    public Transform rightConnection;
    public Transform currentConnection;
    public bool canChangeDirection = false;
    private int currentDirectionId;

    public PointEvent pointEvent;

    void Start()
    {
        // округляем координаты точки (себя)
        transform.position = new Vector3(Mathf.Round(transform.position.x*10)/10, Mathf.Round(transform.position.y*10)/10, transform.position.z);

        if (canChangeDirection)
        {
            // задаем массив соединенных точек
            connections[0] = topConnection;
            connections[1] = rightConnection;
            connections[2] = downConnection;
            connections[3] = leftConnection;

            currentDirectionId = 0;
            // назначаем текущее соединение если его нет
            foreach (Transform connecDir in connections)
            {
                Debug.Log("GAMEOBJECT: " + gameObject.name);
                if (connecDir != null)
                {
                    Debug.Log("-CONNECTION: " + connecDir + " num__" + currentConnection);
                    currentConnection = connecDir;
                    transform.parent.GetComponent<AllPointsParent>().ChangeTileDirection(transform.position, -90 - 90 * currentDirectionId);
                    break;
                }
                currentDirectionId++;
            }
        }
    }

    // возвращаем текущее соединение
    public Transform GetConnection()
    {
        if (currentConnection)
        {
            return currentConnection;
        }

        return null;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canChangeDirection){
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerId = LayerMask.NameToLayer("Interactible");
            var allHits = Physics2D.RaycastAll(mousePos, Vector2.zero, 1000);
            foreach(RaycastHit2D hit in allHits){
            if(hit.collider.gameObject == this.gameObject){
                RotateConveyorCell(transform.position);
            }
            }
        }
    }

    /*
    void OnMouseDown()
    {
        if (canChangeDirection)
        {
            // если мы нажали на тайл конвеера с возможностью поворота
            RotateConveyorCell(transform.position);
        }
    }*/

    private void RotateConveyorCell(Vector3 cellPosition)
    {
        // запускаем цикл
        // всего сторон 4 - проверка возможных 4 направлений
        for (int i = 0; i < 4; i++)
        {
            // счетчик направления 
            if (currentDirectionId < 3)
            {
                currentDirectionId++;
            }
            else
            {
                currentDirectionId = 0;
            }
            // если на этом напралении есть соединение
            if (connections[currentDirectionId] != null)
            {
                // поворачиваем конвеер в эту сторону
                currentConnection = connections[currentDirectionId];
                Debug.Log(currentDirectionId + "_____" + connections[currentDirectionId] + " gameObj: " + gameObject.name);
                transform.parent.GetComponent<AllPointsParent>().ChangeTileDirection(cellPosition, -90 - 90 * currentDirectionId);
                break;
            }
        }
    }
}
