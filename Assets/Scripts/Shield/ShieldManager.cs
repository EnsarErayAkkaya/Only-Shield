using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public Shield shield;
    public SpriteRenderer spriteRenderer;
    public ShieldObject activeShield;
    public List<ShieldObject> ownedShields;
    [Header("Angles")]
    public float down_angle;
    public float down_left_angle;
    public float left_angle;
    public float up_left_angle;
    public float up_angle;
    public float up_right_angle;
    public float right_angle;
    public float down_right_angle;
    
    int shieldIndex = 5;

    public float yellow_Cooldown;
    public float red_Cooldown;
    public float lastUsed;
    public float cooldown;

    private void Start() 
    {
        cooldown = yellow_Cooldown;
    }
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            ChangeShield();
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            if( Time.time - lastUsed < cooldown )
            {
                Debug.Log("on cooldown");
                return;
            }

            lastUsed = Time.time;

            activeShield.Ability();
        }   
    }
    public void UpdateShieldSprite(Vector2 dir)
    {
        if(!shield.canReflect)
        {
            if(dir.x == 0 && dir.y == -1 || dir.x == 0 && dir.y == 0) // down
            {
                SpriteAndColliderChange( activeShield.down, down_angle);
            }
            else if(dir.x > .5f && dir.y < -.5f)// down_left
            {
                SpriteAndColliderChange( activeShield.down_left, down_left_angle);
            }
            else if(dir.x == 1 && dir.y == 0)// left
            {
                SpriteAndColliderChange( activeShield.left, left_angle);
            }
            else if(dir.x > .5f && dir.y > .5f)// up_left
            {
                SpriteAndColliderChange( activeShield.up_left, up_left_angle);
            }
            else if(dir.x == 0 && dir.y == 1)// up
            {
               SpriteAndColliderChange( activeShield.up, up_angle);
            }
            else if(dir.x < -.5f && dir.y > .5f)// up_right
            {
                SpriteAndColliderChange( activeShield.up_right, up_right_angle);
            }
            else if(dir.x == -1 && dir.y == 0) // right
            {
                SpriteAndColliderChange( activeShield.right, right_angle);
            }
            else if(dir.x < -.5f && dir.y < -.5f) // right_down
            {
                SpriteAndColliderChange( activeShield.down_right, down_right_angle);
            }
        }
        else
        {
            if(dir.x == 0 && dir.y == -1 || dir.x == 0 && dir.y == 0)//down
            {
                SpriteAndColliderChange( activeShield.defend_down, down_angle);
            }
            else if(dir.x > .5f && dir.y < -.5f)//down_left
            {
                SpriteAndColliderChange( activeShield.defend_down_left, down_left_angle);
            }
            else if(dir.x == 1 && dir.y == 0)//left
            {
                SpriteAndColliderChange( activeShield.defend_left, left_angle);
            }
            else if(dir.x > .5f && dir.y > .5f)//up_left
            {
                SpriteAndColliderChange( activeShield.defend_up_left, up_left_angle);
            }
            else if(dir.x == 0 && dir.y == 1)//up
            {
                SpriteAndColliderChange( activeShield.defend_up, up_angle);
            }
            else if(dir.x < -.5f && dir.y > .5f)//up_right
            {
                SpriteAndColliderChange( activeShield.defend_up_right, up_right_angle);
            }
            else if(dir.x == -1 && dir.y == 0)//right
            {
                SpriteAndColliderChange( activeShield.defend_right, right_angle);
            }
            else if(dir.x < -.5f && dir.y < -.5f)//down_right
            {
                SpriteAndColliderChange(activeShield.defend_down_right, down_right_angle);
            }
        }
    }
    void SpriteAndColliderChange(Sprite s, float f)
    {
        spriteRenderer.sprite = s;
        shield.transform.rotation = Quaternion.Euler(new Vector3(0,0,f));
    }
    public void PickShield(ShieldObject s)
    {
        ownedShields.Add(s);
    }
    public void ChangeShield()
    {
        shieldIndex++;
        if(shieldIndex >= ownedShields.Count)
        {
            shieldIndex = 0;
        }
        activeShield = ownedShields[shieldIndex];
        if(activeShield is  RedShield)
        {
            cooldown = red_Cooldown;
        }
        else if(activeShield is  YellowShield)
        {
            cooldown = yellow_Cooldown;
        }    
    }
}
