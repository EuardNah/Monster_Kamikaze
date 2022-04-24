using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 20f)] float spawnInterval;
    [SerializeField] Enumymovement enemyPrefab; 

    [SerializeField] AudioClip enemySpawnSoundFX;

    public int enemyCount = 14;

    
    // Start is called before the first frame update
    void Start()
    {
        int scenIndex =  SceneManager.GetActiveScene().buildIndex;
     
       if(scenIndex == 1)
       {
           enemyCount = 14;
           
       }else
       {
           enemyCount = 19;
           
       }
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        
      while(enemyCount>0)
      {
          enemyCount--;
          print(enemyCount);
          GetComponent<AudioSource>().PlayOneShot(enemySpawnSoundFX);
          var newEnemy = Instantiate(enemyPrefab,transform.position,Quaternion.identity);
          newEnemy.transform.parent = transform;
          yield return new WaitForSeconds(spawnInterval);
      }  
    }

}
