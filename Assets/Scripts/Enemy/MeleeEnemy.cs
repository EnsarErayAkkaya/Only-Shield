using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyBase
{
    Player player;
    float distanceBetweenBlocks = 1;
    float attackDistance = 1;
    Rigidbody2D rb;
    public float speed;
    public Animator animator;
    void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        Invoke("CalculateMove",1);
    }
    public void CalculateMove()
    {
        Vector3 dist = player.transform.position - transform.position;
        
        dist /= distanceBetweenBlocks;
        
        Vector3 newPos = Vector3.zero;
        
        if(dist == Vector3.zero)
            return;

        if( dist.y > .1f || dist.y < -.1f )
        {
            int dir =  (dist.y == 0.0f? 0 : dist.y > 0.0f?1:-1);
            newPos = new Vector3(transform.position.x, transform.position.y + (dir * distanceBetweenBlocks), transform.position.z );
        }
        else if(dist.x > .1f || dist.x < -.1f)
        {        
            int dir =  (dist.x == 0.0f? 0 : dist.x > 0.0f? 1:-1);
            
            newPos = new Vector3(transform.position.x + (dir * distanceBetweenBlocks), transform.position.y, transform.position.z );
        }
        else if(dist.z > .1f || dist.z < -.1f)
        {
            int dir =  (dist.z == 0.0f? 0 : dist.z > 0.0f?1:-1);

            newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + (dir * distanceBetweenBlocks) );
        }
        if(dist.magnitude <= attackDistance)
        {
            animator.SetTrigger("attack");
        }
        StartCoroutine( LerpPosition(newPos) );
    }
    
    IEnumerator LerpPosition(Vector3 newPos)
    {
        float t = 0;
        Vector3 startingPos = transform.position; 
        while( t < 1 )
        {
            t += Time.deltaTime;
            Vector3 dir = newPos - startingPos;
            rb.MovePosition(transform.position + dir * speed * t);
            yield return null;
        }
        CalculateMove();
    }
    
    
}
