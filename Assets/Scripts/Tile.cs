using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Tooltip("The Tower to be created when the user clicks")]
    [SerializeField] Tower towerPrefab;
    [Tooltip("Can the player place items on this time?")] 
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

    void Awake() {
        gridManager = FindObjectOfType<GridManager>();
    }

    void Start() {
        if(gridManager != null) {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            if(!isPlaceable) {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    private void OnMouseDown() {
        if (isPlaceable) {
            bool isPlaced = towerPrefab.InstantiateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }      
    }
}