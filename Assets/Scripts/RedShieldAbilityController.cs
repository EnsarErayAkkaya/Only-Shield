using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShieldAbilityController : MonoBehaviour
{
    public float duration;
    Transform player;
    private void Start() 
    {
        player = FindObjectOfType<Player>().transform;
        Destroy(gameObject, duration);
    }
    void Update()
    {
        transform.position = player.transform.position;
    }
    private void OnDestroy() 
    {
        ShieldManager s = FindObjectOfType<ShieldManager>();
        s.shield.canReflect = false;
        s.spriteRenderer.enabled = true;
    }
}
