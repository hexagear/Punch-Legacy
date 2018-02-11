using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestructor : MonoBehaviour {    

    //public LayerMask ground;


    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(collision.gameObject);
        collision.gameObject.SetActive(false);                
    }
}
