using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [Tooltip("The Tower to be created when the user clicks")]
    [SerializeField] Tower towerPrefab;
    [Tooltip("Can the player place items on this time?")] 
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    private void OnMouseDown() {
        if (isPlaceable) {
            bool isPlaced = towerPrefab.InstantiateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }      
    }
}