using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMover : MonoBehaviour {

    public List<Rigidbody2D> rigidbodyList;
    public float speed;
    public float unpausedSpeed;
    public LayerMask physicsLayers;

    private Rigidbody2D[] rigidbodyArray;
    
    
    // Use this for initialization
	void Start () {        
        rigidbodyList = new List<Rigidbody2D>();
        rigidbodyArray = GetComponentsInChildren<Rigidbody2D>();
        //rigidbodyArray = FindObjectsOfType<Rigidbody2D>();
        for (int i = 0; i < rigidbodyArray.Length; i++)
        {
            rigidbodyList.Add(rigidbodyArray[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < rigidbodyList.Count; i++)
        {
            if (moverAffectedCheck(rigidbodyList[i].gameObject))
            {
                rigidbodyList[i].velocity = Vector3.left * speed;
            }            
        }        
	}

    private bool moverAffectedCheck(GameObject obj)
    {
        if (((1 << obj.gameObject.layer) & physicsLayers) != 0)
        {
            return true;
        }
        return false;
    }
}
