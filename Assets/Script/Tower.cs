using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[SelectionBase]

public class Tower : MonoBehaviour
{
    [SerializeField] Transform towerTop;
    [SerializeField] Transform targetEnemy;

    [SerializeField] float shootRange;
    [SerializeField] ParticleSystem bulletParticles;
    [SerializeField] Winner winnerload;
    public Waypoint baseWaypoint;
    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        
        if(targetEnemy)
        {
            towerTop.LookAt(targetEnemy);
            Fire();
        }
        else
        {
            Shoot(false);
        }
        
    }

    private void SetTargetEnemy()
    {
        winnerload = FindObjectOfType<Winner>();
        
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        PlayerPrefs.SetInt("sceneEnemis", sceneEnemies.Length);
        if (sceneEnemies.Length == 0)
        {    
            int scen = SceneManager.GetActiveScene().buildIndex;
            winnerload.WinnerMenu(scen);
            print("towers print scen " + scen);
            SceneManager.LoadScene(1);
            return;
        }
        Transform closestEnemy = sceneEnemies[0].transform;
        foreach(EnemyDamage test in sceneEnemies)
        {
            
            
            closestEnemy = GetClosestEnemy(closestEnemy.transform, test.transform);
        }

        targetEnemy=closestEnemy;

    }

    private Transform GetClosestEnemy(Transform enemyA, Transform enemyB)
    {
        var distToA = Vector3.Distance(enemyA.position,transform.position);
        var distToB = Vector3.Distance(enemyB.position,transform.position);
        if(distToA<distToB)
        {
            return enemyA;
        }
        return enemyB;
    }

    private void Fire()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.position,transform.position);
        if(distanceToEnemy <= shootRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        //bulletParticles.enableEmission = isActive;
        var emission = bulletParticles.emission;
        emission.enabled = isActive;
    }
}
