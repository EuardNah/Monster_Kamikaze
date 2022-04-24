using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]


[RequireComponent(typeof(Waypoint))]

public class CubeEditor: MonoBehaviour
{
    Waypoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();

        UpdateLabel();

    }
    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x*gridSize,0f,waypoint.GetGridPos().y*gridSize);
    }

    private void UpdateLabel()
    {
        TextMesh label = GetComponentInChildren<TextMesh>();
        string labelName = waypoint.GetGridPos().x + ";" + waypoint.GetGridPos().y;
        label.text = labelName;
        gameObject.name = labelName;
    }

    
}
