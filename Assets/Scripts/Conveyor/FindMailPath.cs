using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMailPath : MonoBehaviour
{
    List<Transform> explored = new List<Transform>();
    List<Transform> tracking = new List<Transform>();
    public Transform GetRightMovePoint(int color, Transform[] connections)
    {
        AddPointToTracking(connections);

        while (tracking.Count > 0)
        {
            foreach (Transform point in tracking)
            {
                if ((int)point.gameObject.GetComponent<PointEvent>().color == color)
                {
                    return point;
                }
                else
                {
                    explored.Add(point);
                    AddPointToTracking(point.gameObject.GetComponent<PointConnections>().connections);
                }
            }
        }
        Debug.LogError("COLOR NOT FOUND!");
        return null;
    }

    private void AddPointToTracking(Transform[] points)
    {
        foreach (Transform point in points)
        {
            tracking.Add(point);
        }
    }
}
