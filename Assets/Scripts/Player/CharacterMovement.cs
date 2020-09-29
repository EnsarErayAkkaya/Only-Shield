using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public Vector2 moveVector;
    public Vector2 animateVector;
    private float X;
    private float Y;
    Rigidbody2D rb;
    bool moving;
    public Animator animator;
    public ShieldManager shieldManager;
    public Collider2D collider;
    public bool canMove = true;
    public bool dash;
    float dashSpeed;
    float dashDuration;
    float currentDashTime = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        collider = GetComponent<Collider2D>(); 
    }
    private void FixedUpdate() 
    {  
        if(moving && canMove)
            rb.MovePosition((Vector2)transform.position + moveVector * speed * Time.fixedDeltaTime);
        else if(dash)
        {
            if(currentDashTime < dashDuration)
            {
                currentDashTime += Time.fixedDeltaTime;
                rb.MovePosition(transform.position + (Vector3)animateVector * dashSpeed * currentDashTime);
            }
            else{
                DashEnded();
            }

        }
    }

    private void Update() 
    {
        Move();
        shieldManager.UpdateShieldSprite(animateVector);
    }
    void Move()
    {
        if(canMove)
        {
            rb.velocity = Vector2.zero;
            X = Input.GetAxisRaw("Horizontal");
            Y = Input.GetAxisRaw("Vertical");
            
            moveVector.x = X;
            moveVector.y = Y;
            moveVector.Normalize();

            if(moveVector.magnitude > 0)
            {
                moving = true;
                animateVector = moveVector; 
                Animate();
            }
            else
            {
                moving = false;
            }
        }
    }
    void Animate()
    {
        animator.SetFloat("Horizontal", moveVector.x);
        animator.SetFloat("Vertical", moveVector.y);
    }
    public void Dash(float dashSpeed, float dashDuration)
    {
        dash = true;
        this.dashSpeed = dashSpeed;
        this.dashDuration = dashDuration;
    }
    void DashEnded()
    {
        dash = false;
        canMove = true;
        currentDashTime = 0;
    }
}
