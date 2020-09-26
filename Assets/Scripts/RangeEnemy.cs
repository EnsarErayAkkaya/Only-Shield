using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    Transform target;
    public GameObject projectile;
    public float shootingDist;
    public bool canShoot;
    public float timeBetweenShots;
    public float projectileDistanceToCenter;
    float remainingtTmeBetweenShots;
    
    private void Start() 
    {
        target = FindObjectOfType<Player>().transform;
    }
    private void Update() 
    {
        Shoot();
    }
    void Shoot()
    {
        if ( canShoot && Vector3.Distance(target.position, transform.position) < shootingDist )
        {            
            if(remainingtTmeBetweenShots <= 0)
            {
                Vector2 dir = (target.position - transform.position).normalized * projectileDistanceToCenter;
                Vector2 pos = new Vector2(transform.position.x + dir.x,transform.position.y+ dir.y);
                Instantiate(projectile, pos, Quaternion.identity);

                remainingtTmeBetweenShots = timeBetweenShots;
            }
            else
            {
                remainingtTmeBetweenShots -= Time.deltaTime;
            }
        }
    }
}
