using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enumymovement : MonoBehaviour
{
    [SerializeField] ParticleSystem castleDamageParticles;
    [SerializeField] float speed;

    [SerializeField] float moveStep;
    PathFinder pathfinder;
    
    EnemyDamage enemyDemage;

    Castle castle;

    Vector3 targetPosition;
    void Start()
    {
        castle = FindObjectOfType<Castle>();
        enemyDemage = FindObjectOfType<EnemyDamage>();
        pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(EnemyMove(path));
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,targetPosition,Time.deltaTime*moveStep);
        
    }

    // Update is called once per frame
    IEnumerator EnemyMove(List<Waypoint> path)
    {
        
        foreach (Waypoint waypoint in path)
        {
            transform.LookAt(waypoint.transform);
            
            targetPosition = waypoint.transform.position;
            yield return new WaitForSeconds(speed);
        }
        castle.Damage();
        enemyDemage.DestroyEnemy(castleDamageParticles,false);
        
    }
}
