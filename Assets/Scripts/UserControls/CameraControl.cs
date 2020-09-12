using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform leftDownCorner;
    public Transform rightTopCorner;

    void Start()
    {
        TransformToAvalbleBound();
    }

    private Vector2 mouseStartPos;
    private Vector2 mouseEndPos;

    private bool draging = false;
    private void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // нажимаем клавишу мыши
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            draging = true;
        }

        // отпускаем клавишу мыши
        if (Input.GetMouseButtonUp(0))
        {
            draging = false;
        }

        // перетаскиваем
        if (draging)
        {
            // изменяем скорость камеры в зависимости от длины перетаскивания
            float dragSpeed = Vector2.Distance(mouseStartPos, mousePos) / 300;
            var curPos = transform.position;

            if(Vector2.Distance(mouseStartPos, mousePos) < 1){
                dragSpeed *= 1.5f;
            }
            // находим позицию в которую мы собираемся переместиться
            float xAbs = mousePos.x - mouseStartPos.x;
            float yAbs = mousePos.y - mouseStartPos.y;

            Vector2 newReversePositionCoords = new Vector2(transform.position.x - xAbs, transform.position.y - yAbs);

            float newXposition = Mathf.Lerp(transform.position.x, newReversePositionCoords.x, dragSpeed);
            float newYposition = Mathf.Lerp(transform.position.y, newReversePositionCoords.y, dragSpeed);
            var newPosition = new Vector3(newXposition, newYposition, curPos.z);
            // вычисляем изменение нижней левой границы (для данной ширины камеры)
            Vector2 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

            float bottomLeftNewX = Mathf.Lerp(bottomLeft.x, newReversePositionCoords.x, dragSpeed);
            float bottomLeftNewY = Mathf.Lerp(bottomLeft.y, newReversePositionCoords.y, dragSpeed);

            bottomLeft = new Vector2(bottomLeftNewX, bottomLeftNewY);
            // вычисляем изменение верхней правой границы (для данной ширины камеры)
            float cameraWidth = Camera.main.pixelWidth;
            float cameraHeight = Camera.main.pixelHeight;

            Vector2 topRight = Camera.main.ScreenToWorldPoint(new Vector2(cameraWidth, cameraHeight));

            float topRightNewX = Mathf.Lerp(topRight.x, newReversePositionCoords.x, dragSpeed);
            float topRightNewY = Mathf.Lerp(topRight.y, newReversePositionCoords.y, dragSpeed);

            topRight = new Vector2(topRightNewX, topRightNewY);
            // проверяем не будем выходить ли мы за допустимые границы
            if (bottomLeft.x > leftDownCorner.position.x  && topRight.x < rightTopCorner.position.x)
            {
                transform.position = new Vector3(newXposition, transform.position.y, curPos.z);
            }
            if (bottomLeft.y > leftDownCorner.position.y && topRight.y < rightTopCorner.position.y)
            {
                transform.position = new Vector3(transform.position.x, newYposition, curPos.z);
            }

            // TransformToAvalbleBound();
        }
    }

    private void TransformToAvalbleBound()
    {
        // если мы за границами, то перемещаемся к границе
        if (transform.position.x < leftDownCorner.position.x)
        {
            transform.position = new Vector3(leftDownCorner.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y < leftDownCorner.position.y)
        {
            transform.position = new Vector3(transform.position.x, leftDownCorner.position.y, transform.position.z);
        }
        if (transform.position.x > rightTopCorner.position.x)
        {
            transform.position = new Vector3(rightTopCorner.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y > rightTopCorner.position.y)
        {
            transform.position = new Vector3(transform.position.x, rightTopCorner.position.y, transform.position.z);
        }
    }
}
