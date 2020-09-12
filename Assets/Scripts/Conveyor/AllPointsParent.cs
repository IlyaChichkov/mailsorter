using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AllPointsParent : MonoBehaviour
{
    public List<string> avaliableLevelPointsColors = new List<string>();
    public Tilemap conveyorTilemap;

    public Tilemap conveyorTilem2ap;
    public void ChangeTileDirection(Vector2 position, int angle)
    {
        var cellPosition = conveyorTilemap.WorldToCell(position);
        conveyorTilemap.SetTransformMatrix(cellPosition, Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, angle), new Vector3(1, 1, 1)));
    }
}
