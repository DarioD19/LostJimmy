using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class WaypointPath : MonoBehaviour
{
    [SerializeField] private Color _color;
    public Transform GetWaypoint(int waypointIndex)
    {
        return transform.GetChild(waypointIndex);
    }
    public int GetNextWaypointIndex(int currentWaypointIndex)
    {
        int nextWaypointIndex = currentWaypointIndex + 1;
        if (nextWaypointIndex == transform.childCount)
        {
            nextWaypointIndex = 0;
        }
        return nextWaypointIndex;
    }
    private void OnDrawGizmos()
    {
      
            DrawWaypointGizmos();

        

    }

    public void DrawWaypointGizmos()
    {
        for (int waypointIndex = 0; waypointIndex < transform.childCount; waypointIndex++)
        {
            var waypoint = GetWaypoint(waypointIndex);
            Gizmos.color = _color;
            Gizmos.DrawSphere(waypoint.position, 0.2f);

            int nextWaypointIndex = GetNextWaypointIndex(waypointIndex);
            var nextWaypoint = GetWaypoint(nextWaypointIndex);

            Gizmos.color = _color;
            Gizmos.DrawLine(waypoint.position, nextWaypoint.position);
        }
    }

   
}
