using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Red Shield", menuName = "Shields/Red Shield", order = 0)]
public class RedShield : ShieldObject
{
    public GameObject abilityPrefab;
    ShieldManager shieldManager;
    public override void Ability()
    {
        if(shieldManager == null)
            shieldManager = FindObjectOfType<ShieldManager>();
        shieldManager.shield.canReflect = true;

        shieldManager.spriteRenderer.enabled = false;
        Instantiate(abilityPrefab);
    }
}
