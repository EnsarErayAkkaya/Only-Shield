using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    Vector3 direction;
    Rigidbody2D rb;
    Shield shield;
    private void Awake() 
    {
        shield = FindObjectOfType<Shield>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (FindObjectOfType<Player>().transform.position - transform.position).normalized * speed;
        Destroy(gameObject, 3);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Shield"))
        {
            if(shield.canReflect)
                ReflectProjectile(collision.contacts[0].normal, 3);
            else
                ReflectProjectile(collision.contacts[0].normal, 1f);            
        }
        else if(collision.collider.CompareTag("Player"))
        {
            //particle
            Destroy(gameObject);
        }
    }

    private void ReflectProjectile(Vector3 reflectVector, float velocityMultiplier)
    {    
        rb.velocity = Vector3.Reflect(rb.velocity, reflectVector) * velocityMultiplier;
    }
}
