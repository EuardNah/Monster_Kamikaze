using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public class TawerFactory : MonoBehaviour
{
    [SerializeField] public int towerLimit =2;

    [SerializeField] public bool yes = false ;
   [SerializeField] Tower tawerPrefab;

   
    
   Queue<Tower> towerQueue = new Queue<Tower>();

   void Start()
   {
       
       
     int scenIndex =  SceneManager.GetActiveScene().buildIndex;
     
       if(scenIndex == 2)
       {
           towerLimit =2;
          
       }
       else
       {
           towerLimit =3;
           
       }
   }
    
   public void AddTower(Waypoint baseWaypoint)
   {
       
       BonusTawer BonTaw = FindObjectOfType<BonusTawer>();
       int towerLimitplus = BonTaw.tawerLimitPlus(towerLimit);
       
       int towersCount = towerQueue.Count;
        
        
       if(towersCount < towerLimit)
       {
           InstantiateNewTower(baseWaypoint);
           
       }
       else
       {
           
           towerLimit=towerLimitplus;
           MoveTowerToNewPosition(baseWaypoint);
           
           
       }

    
       
   }

    private void MoveTowerToNewPosition(Waypoint newbaseWaypoint)
    {
        Tower oldTower = towerQueue.Dequeue();
        oldTower.transform.position = newbaseWaypoint.transform.position;
        oldTower.baseWaypoint.isPlaceable = true;
        newbaseWaypoint.isPlaceable =false;
        oldTower.baseWaypoint = newbaseWaypoint;
        towerQueue.Enqueue(oldTower);
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(tawerPrefab,baseWaypoint.transform.position,Quaternion.identity);
        newTower.transform.parent = transform;
        baseWaypoint.isPlaceable = false;
        newTower.baseWaypoint= baseWaypoint;
        towerQueue.Enqueue(newTower);
    }
}
