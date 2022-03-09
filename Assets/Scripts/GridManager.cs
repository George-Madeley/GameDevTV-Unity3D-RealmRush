using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;

    [Tooltip("The world grid size should match the UnityEditior snap settings")]
    [SerializeField] int unityGridSize = 10;
    public int UnityGridSize { get { return unityGridSize; } }

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }

    private void Awake() {
        CreateGrid();
    }

    public Node GetNode(Vector2Int coordinate) {
        if(grid.ContainsKey(coordinate)) {
            return grid[coordinate];
        }
        return null;
    }

    public void BlockNode(Vector2Int coordinates) {
        if(grid.ContainsKey(coordinates)){
            grid[coordinates].isWalkable = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position) {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);
        return coordinates;
    }

    public Vector3 GetPositionFromCoordiantes(Vector2Int coordiantes) {
        Vector3 position = new Vector3();
        position.x = coordiantes.x * unityGridSize;
        position.z = coordiantes.y * unityGridSize;
        return position;
    }

    private void CreateGrid()
    {
        for(int x = 0; x < gridSize.x; x++) {
            for(int y = 0; y < gridSize.y; y++) {
                Vector2Int coordinates = new Vector2Int(x, y);
                /*
                Node will have a value of true until we know
                whether of not the node is walkable by the rams.
                */
                grid.Add(coordinates, new Node(coordinates, true));
            }
        }
    }
}
