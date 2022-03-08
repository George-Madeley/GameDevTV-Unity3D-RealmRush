using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [Tooltip("The Default color for the coordinates")]
    [SerializeField] Color defaultColor = Color.white;
    [Tooltip("The Color for the coordinates when a block cannot be placed on the tile")]
    [SerializeField] Color blockedColor = Color.gray;
    [Tooltip("The Color for the coordinates when a tile is explored")]
    [SerializeField] Color exploredColor = Color.yellow;
    [Tooltip("The Color for the coordinates when a tile is a path")]
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;

    private void Awake() {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying){
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
        }
        SetLabelColor();
        ToggleLabels();
    }

    private void ToggleLabels() {
        if(Input.GetKeyDown(KeyCode.C)) {
            label.enabled = !label.IsActive();
        }
    }

    private void SetLabelColor()
    {
        if(gridManager == null) { return; }

        Node node = gridManager.GetNode(coordinates);

        if(node == null) { return; }

        if(!node.isWalkable) {
            label.color = blockedColor;
        } else if(node.isPath) {
            label.color = pathColor;
        } else if(node.isExplored) {
            label.color = exploredColor;
        } else {
            label.color = defaultColor;
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
    }

    private void UpdateObjectName() {
        transform.parent.name = coordinates.ToString();
    }
}
