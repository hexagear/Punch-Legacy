using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public LayerMask ground;

    private Rigidbody2D myRigidbody;
    public bool grounded, jab, jumpkick, airkick, airslam, leftHand;
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

        Physics2D.IgnoreLayerCollision(9, 11);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    void Update()
    {

        grounded = Physics2D.IsTouchingLayers(myCollider, ground);

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) 
            | Input.GetMouseButtonDown(1)
            )
        {
            TapLeft();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) 
            | Input.GetMouseButtonDown(0)
            )
        {
            TapRight();
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
        myAnimator.SetFloat("Y speed", myRigidbody.velocity.y);
        myAnimator.SetBool("Jab", jab);
        myAnimator.SetBool("Left hand", leftHand);
        myAnimator.SetBool("Airkick", airkick);
        myAnimator.SetBool("Airslam", airslam);
    }


    public void TapRight()
    {
        //Jab
        if (grounded)
        {
            jab = true;
            leftHand = !leftHand;
            AttackUse("Jab");            
        }
        //Airkick
        else
        {
            airkick = true;
            AttackUse("Airkick");            
        }
    }

    public void TapLeft()
    {
        //Jumpkick
        if (grounded)
        {            
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            jumpkick = true;
            AttackUse("Jumpkick");            
        }
        //Airslam
        else
        {
            airslam = true;
            AttackUse("Airslam");
        }
    }

    public void AttackUse(string attackName)
    {
        attackBool = true;
        for (int i = 0; i < punchArray.Length; i++)
        {
            if (punchArray[i].gameObject.name == attackName)
            {
                punchArray[i].gameObject.SetActive(true);
            }
        }
    }

    public void AttackEnd(string attackName)
    {
        for (int i = 0; i < punchArray.Length; i++)
        {
            if (punchArray[i].gameObject.name == attackName)
            {
                punchArray[i].gameObject.SetActive(false);
            }
        }
    }

    public void JabEnd()
    {
        jab = false;
        AttackEnd("Jab");
    }

    public void JumpkickEnd()
    {        
        jumpkick = false;
        AttackEnd("Jumpkick");       
    }

    public void AirkickEnd()
    {
        airkick = false;
        AttackEnd("Airkick");        
    }

    public void AirslamEnd()
    {
        airslam = false;
        AttackEnd("Airslam");
    }
}
