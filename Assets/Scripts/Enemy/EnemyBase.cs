using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Room room;
    public int maxHealth = 1;
    public int currentHealth;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("Player") || other.collider.CompareTag("Projectile"))
        {
            TakeDamage();
        }
    }
    
    private void Start() 
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage()
    {
        currentHealth--;
        if(currentHealth < 0)
        {
            currentHealth = 0;
            Die();
        }
        else if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    protected void Die()
    {
        room.enemys.Remove(gameObject);
        //particle
        Destroy(gameObject);
    }
}
