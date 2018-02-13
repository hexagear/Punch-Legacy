using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public LayerMask ground;

    private Rigidbody2D myRigidbody;
    public bool grounded, jab, jumpkick, leftHand;
    private Collider2D myCollider;
    private Animator myAnimator;
    private BoxCollider2D[] punchArray;

    // Use this for initialization
    void Start()
    {
        leftHand = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();

        punchArray = GetComponentsInChildren<BoxCollider2D>();
        for (int i = 0; i < punchArray.Length; i++)
        {
            punchArray[i].gameObject.SetActive(false);
        }
        punchArray[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        grounded = Physics2D.IsTouchingLayers(myCollider, ground);

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) | Input.GetMouseButtonDown(1))
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpkick = true;
                for (int i = 0; i < punchArray.Length; i++)
                {
                    if (punchArray[i].gameObject.name == "Jumpkick")
                    {
                        punchArray[i].gameObject.SetActive(true);
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                jab = true;
                for (int i = 0; i < punchArray.Length; i++)
                {
                    if (punchArray[i].gameObject.name == "Jab")
                    {
                        punchArray[i].gameObject.SetActive(true);
                    }
                }
            }
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
        myAnimator.SetFloat("Y speed", myRigidbody.velocity.y);
        myAnimator.SetBool("Jab", jab);
        myAnimator.SetBool("Left hand", leftHand);
    }
    

    public void jabEnd()
    {
        jab = false;
        leftHand = !leftHand;
        for (int i = 0; i < punchArray.Length; i++)
        {
            if (punchArray[i].gameObject.name == "Jab")
            {
                punchArray[i].gameObject.SetActive(false);
            }
        }
    }

    public void jumpkickEnd()
    {
        jumpkick = false;
        for (int i = 0; i < punchArray.Length; i++)
        {
            if (punchArray[i].gameObject.name == "Jumpkick")
            {
                punchArray[i].gameObject.SetActive(false);
            }
        }
    }
}
