using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    //public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;

    //public float distanceBetweenMax;
    //public float distanceBetweenMin;
    public ObjectPooler theObjectPool;
    public EnemyGenerator enemyGenerator;

    // Use this for initialization
    void Start()
    {
        ObjectPooler pooler = GetComponent<ObjectPooler>();
        //enemyGenerator = GetComponent<EnemyGenerator>();
        platformWidth = pooler.pooledObject.GetComponent<BoxCollider2D>().size.x;
        enemyGenerator.platformWidth = platformWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            //distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            //Instantiate(thePlatform, transform.position, transform.rotation);

            GameObject newPlatform = theObjectPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            enemyGenerator.lastPlatform = newPlatform.transform;
        }
    }
}
