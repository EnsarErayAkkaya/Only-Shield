using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public Vector2 moveVector;
    private float X;
    private float Y;
    Rigidbody2D rb;
    bool moving;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }
    private void FixedUpdate() 
    {  
        if(moving)
            rb.MovePosition((Vector2)transform.position + moveVector.normalized * speed * Time.fixedDeltaTime);
    }

    private void Update() 
    {
        Look();
        Move();
    }
    void Look()
	{
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle =  (Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg)%360;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
	}
    void Move()
    {
        X = Input.GetAxisRaw("Horizontal");
        Y = Input.GetAxisRaw("Vertical");

        moveVector.x = X;
        moveVector.y = Y;

        if(moveVector.normalized.magnitude > 0)
            moving = true;
    }
}
