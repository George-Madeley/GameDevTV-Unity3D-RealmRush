using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [Tooltip("Can the player place items on this time?")] 
    [SerializeField] bool isPlaceable;

    private void OnMouseDown() {
        if (isPlaceable) {
            Debug.Log(transform.name); 
        }      
    }
}