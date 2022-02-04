using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [Tooltip("A list of tiles with waypoint components that the enemy will follow in order.")]
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [Tooltip("The speed of the enemy")]
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    private IEnumerator FollowPath() {
        foreach(Waypoint waypoint in path){
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f) {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                /*
                'yeild' means to give up control.
                'yeild return' means to give up control but come back to me (me being this function)
                The command below means to give up control but come back to me at the end of the frame.
                */
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
