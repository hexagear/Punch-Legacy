using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health;
    public LayerMask ground;
    public bool isHit, grounded;
    public Rigidbody2D enemyRigidbody;
    public BoxCollider2D enemyCollider;
    public Animator enemyAnimator;    

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(enemyCollider, ground);

        enemyAnimator.SetBool("Grounded", grounded);
        enemyAnimator.SetFloat("SpeedY", enemyRigidbody.velocity.y);
        enemyAnimator.SetBool("IsHit", isHit);
        enemyAnimator.SetInteger("Health", health);
    }

    private void hitEnd()
    {
        isHit = false;
        gameObject.layer = 10;
    }

    private void dead()
    {
        gameObject.layer = 11;        
        //Destroy(enemyCollider);
    }
}
