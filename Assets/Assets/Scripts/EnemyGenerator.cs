using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{    
    private float spawnDistance;
    private ObjectPooler theObjectPool;

    public float platformWidth;
    public Transform lastSpawn;    
    public float spawnChance;
    public Transform lastPlatform;
    

    // Use this for initialization
    void Start()
    {
        theObjectPool = GetComponent<ObjectPooler>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (lastSpawn.position.x < lastPlatform.position.x - platformWidth)
        {
            spawnDistance = Random.Range(0, spawnChance);            

            GameObject enemy = theObjectPool.GetPooledObject();
            enemy.transform.position = lastPlatform.position;
            enemy.transform.rotation = lastPlatform.rotation;
            enemy.SetActive(true);
            lastSpawn.position = lastPlatform.position;
        }
    }
}
