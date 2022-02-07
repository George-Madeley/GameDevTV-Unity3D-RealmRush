using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [Tooltip("The GameObject/Tower to be created when the user clicks")]
    [SerializeField] GameObject towerPrefab;
    [Tooltip("Can the player place items on this time?")] 
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    private void OnMouseDown() {
        if (isPlaceable) {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }      
    }
}