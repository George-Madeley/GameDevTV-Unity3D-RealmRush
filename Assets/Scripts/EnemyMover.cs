using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [Tooltip("A list of tiles with waypoint components that the enemy will follow in order.")]
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [Tooltip("The wait time in seconds between each tile/waypoint movement")]
    [SerializeField] float waitTime = 1f;
    
    void Start()
    {
        StartCoroutine(PrintWaypointName());
    }

    private IEnumerator PrintWaypointName() {
        foreach(Waypoint waypoint in path){
            MoveToWaypoint(waypoint);
            /*
            'yeild' means to give up control.
            'yeild return' means to give up control but come back to me (me being this function)
            The command below means to give up control but come back to me in 1 second.
            */
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void MoveToWaypoint(Waypoint waypoint)
    {
        transform.position = waypoint.transform.position;
    }
}
