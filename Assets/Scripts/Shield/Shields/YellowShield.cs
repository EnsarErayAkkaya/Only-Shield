using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Yellow Shield", menuName = "Shields/Yellow Shield", order = 0)]
public class YellowShield : ShieldObject
{
    public float dashDuration;
    public float dashSpeed;
    CharacterMovement movement;
    public override void Ability()
    {
        if(movement == null)
            movement = FindObjectOfType<CharacterMovement>();
            
        movement.canMove = false;
        movement.Dash( dashSpeed, dashDuration );
    }
    
}
