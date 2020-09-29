using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
    public ShieldObject shield;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<ShieldManager>().PickShield(shield);
            Destroy(gameObject);
        }
    }
}
