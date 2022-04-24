using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField]Waypoint startPoint,endPoint;
    Dictionary<Vector2Int,Waypoint> grid=new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField]bool isRunning = true;
    Waypoint searchPoint;

    public List<Waypoint> path = new List<Waypoint>();
    Vector2Int [] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left

    };
    // Start is called before the first frame update
    
    public List<Waypoint> GetPath()
    {
        if(path.Count ==0)
        {
            CalculatePath();
        }
            return path;
    }

    void CalculatePath()
    {
        LoadBlocks();
        SetColorStartAndEnd();
        PathfindAlgorithm();
        CreatePath();
    }

    void CreatePath()
    {
        
        AddPointToPath(endPoint);
        Waypoint prevPoint = endPoint.exploredFrom;
        while (prevPoint !=startPoint)
        {
            prevPoint.setTopColor(Color.cyan);
            AddPointToPath(prevPoint);
            prevPoint = prevPoint.exploredFrom;
        }
        
        AddPointToPath(startPoint);
        path.Reverse();
    }

    void AddPointToPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }

    void PathfindAlgorithm()
    {
        queue.Enqueue(startPoint);
        while(queue.Count > 0 && isRunning == true)
        {
            searchPoint = queue.Dequeue();
            searchPoint.isExplored=true;
            
            CheckForEndpoint();
            ExploreNearPoints();
        }
    }

    void CheckForEndpoint ()
    {
        if(searchPoint == endPoint)
        {
            isRunning = false;
        }

    }

    void ExploreNearPoints()
    {
        if(!isRunning){return;}
        foreach(Vector2Int direction in directions)
        {
            Vector2Int nearPointCordinates = searchPoint.GetGridPos()+direction;

            if(grid.ContainsKey(nearPointCordinates))
            {
                Waypoint nearPoint = grid[nearPointCordinates];
                AddPointToQueue(nearPoint);
            }
            
            
        }
    }

    private void AddPointToQueue(Waypoint nearPoint)
    {
        if(nearPoint.isExplored || queue.Contains(nearPoint))
        {
            return;
        }
        else
        {
            
            queue.Enqueue(nearPoint);
            nearPoint.exploredFrom = searchPoint;
        }
        
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        
        foreach (Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();
            if( grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Повтор блока : " + waypoint);
            }
            else
            {
                grid.Add(gridPos,waypoint);
                
            }
        }
        

    }

    void SetColorStartAndEnd()
    {
        startPoint.setTopColor(Color.blue);
        endPoint.setTopColor(Color.red);
    }

}
