using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemy;

    public float timeBetweenWaves = 1f;
    private float timeToSpawn = 1f;


    void Update()
    {
        StartSpawning();
    }


    void StartSpawning()
    {
        if (Time.time >= timeToSpawn)
        {
            SpawnBlock();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
    }

    void SpawnBlock()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                int randomEnemy = Random.Range(0, enemy.Length);
                Instantiate(enemy[randomEnemy], spawnPoints[i].position, Quaternion.identity);
            }
        }
    }


}
