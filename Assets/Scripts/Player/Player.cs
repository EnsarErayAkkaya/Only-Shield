using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    UIManager uIManager;
    CharacterMovement characterMovement;
    private void Start() 
    {
        characterMovement =  FindObjectOfType<CharacterMovement>();
        uIManager = FindObjectOfType<UIManager>();
        currentHealth = maxHealth;
        uIManager.UpdateHealthImage(currentHealth);
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("Projectile"))
        {
            if(!characterMovement.dash)
                TakeDamage();
        } 
        else if(other.collider.CompareTag("Enemy"))
        {
            if(!characterMovement.dash)
                TakeDamage();
        }    
    }
    void TakeDamage()
    {
        currentHealth--;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            uIManager.UpdateHealthImage(currentHealth);
            Die();
        }
        else if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            uIManager.UpdateHealthImage(currentHealth);
        }
        uIManager.UpdateHealthImage(currentHealth);
    }
    void Die()
    {
        SceneManager.LoadScene(0);
    }
}
