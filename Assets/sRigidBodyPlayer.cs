using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sRigidBodyPlayer : MonoBehaviour
{
    public bool enemyCollision = false;
    public int damageEnemy;
    public Rigidbody rb;
    public Vector3 rbT;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == 7)
        {
            //arrumar essa desgraça
            damageEnemy = collider.gameObject.GetComponent<sEnemy>().damagePlayer;
            rb.AddForce(-transform.forward * 1f, ForceMode.Impulse);
            rbT = rb.position;
            enemyCollision = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == 7)
        {
            enemyCollision = false;
        }
    }
}
