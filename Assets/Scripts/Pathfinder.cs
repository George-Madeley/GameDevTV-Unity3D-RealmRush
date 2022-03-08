using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinate;
    [SerializeField] Vector2Int destinationCoordinate;

    Node startNode;
    Node destinationNode;
    Node currentSearchNode;

    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    void Awake() {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null) {
            grid = gridManager.Grid;
        }
    }

    void Start()
    {
        startNode = gridManager.Grid[startCoordinate];
        destinationNode = gridManager.Grid[destinationCoordinate];
        BreadFirstSearch();
        BuildPath();
    }

    private void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();
        foreach(Vector2Int direction in directions) {
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction;
            if(grid.ContainsKey(neighborCoords)) {
                neighbors.Add(grid[neighborCoords]);
            }
        }
        foreach(Node neighbor in neighbors) {
            if(!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable) {
                neighbor.connectedTo = currentSearchNode;
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }

    private void BreadFirstSearch() {
        bool isRunning = true;
        frontier.Enqueue(startNode);
        reached.Add(startCoordinate, startNode);
        while(frontier.Count > 0 && isRunning) {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if(currentSearchNode.coordinates == destinationCoordinate) {
                isRunning = false;
            }
        }
    }

    private List<Node> BuildPath() {
        List<Node> path = new List<Node>();
        Node curreentNode = destinationNode;
        path.Add(curreentNode);
        curreentNode.isPath = true;
        while(curreentNode.connectedTo != null) {
            curreentNode = curreentNode.connectedTo;
            path.Add(curreentNode);
            curreentNode.isPath = true;
        }
        path.Reverse();
        return path;
    }
}
