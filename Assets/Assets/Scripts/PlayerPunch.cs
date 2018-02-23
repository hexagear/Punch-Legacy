using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour {

    public int damage;
    public float forceX;
    public float forceY;
    public float corpsesRotationForce;

    public LayerMask layers;

    private EnemyController enemyController;
    private Rigidbody2D enemyRigidbody;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & layers) != 0)
        {
            enemyController = collision.gameObject.GetComponent<EnemyController>();
            enemyRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            enemyController.health -= damage;
            if (enemyController.health<=0)
            {
                enemyRigidbody.freezeRotation = false;
                enemyRigidbody.angularVelocity=corpsesRotationForce;
                enemyRigidbody.gameObject.layer = 12;
            }
            
            enemyController.isHit = true;
            enemyRigidbody.velocity = new Vector2(forceX, forceY);
            enemyController.gameObject.layer = 11;
            Debug.Log("HIT");
        }
    }

}
