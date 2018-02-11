using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private PlayerController thePlayer;

    //private Vector3 lastPlayerPosition;
    private float offcet;

    
    // Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        offcet = transform.position.x - thePlayer.transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(thePlayer.transform.position.x + offcet, transform.position.y, transform.position.z);
	}
}
