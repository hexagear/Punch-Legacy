using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public GameObject pooledObject;
    public GameObject platforms;
    public int pooledAmount;
    private float speed;
    private LevelMover mover;

    List<GameObject> objectsList;

    // Use this for initialization
    void Start()
    {
        objectsList = new List<GameObject>();

        mover = FindObjectOfType<LevelMover>();
        

        for (int i = 0; i < pooledAmount; i++)
        {            
            GameObject obj = (GameObject)Instantiate(pooledObject, platforms.transform);
            obj.transform.parent = platforms.transform;
            obj.SetActive(false);
            objectsList.Add(obj);
            mover.rigidbodyList.Add(obj.GetComponent<Rigidbody2D>());
        }
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < objectsList.Count; i++)
        {
            if (!objectsList[i].activeInHierarchy)
            {
                return objectsList[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObject, platforms.transform);
        obj.transform.parent = platforms.transform;
        obj.SetActive(false);
        objectsList.Add(obj);
        mover.rigidbodyList.Add(obj.GetComponent<Rigidbody2D>());
        return obj;
    }
}
