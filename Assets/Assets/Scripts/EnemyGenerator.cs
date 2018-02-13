using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{    
    private ObjectPooler theObjectPool;

    public float spawnDistance;
    public int health;
    public float platformWidth;
    public Transform lastSpawn;
    //public float spawnChance;
    public Transform lastPlatform;


    // Use this for initialization
    void Start()
    {
        theObjectPool = GetComponent<ObjectPooler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastSpawn.position.x < lastPlatform.position.x - platformWidth * spawnDistance)
        {
            GameObject enemy = theObjectPool.GetPooledObject();
            enemy.transform.position = lastPlatform.position;
            enemy.transform.rotation = lastPlatform.rotation;
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            enemyController.health = health;
            enemy.SetActive(true);
            enemy.layer = 10;
            lastSpawn.position = lastPlatform.position;
        }
    }
}
