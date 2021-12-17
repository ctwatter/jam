using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float speed;
    public int maxWallBounces = 0;
    public int currWallBounces = 0;
    public Vector3 target;
    public Rigidbody rb;

    private bool doMove = false;

    public virtual void HitEnemy(GameObject enemy)
    {
        //rolly -> do damage - then chain/x to next enemy;
        //tick -> stick to enemy, do damage, explode in aoe
        //flea -> slow enemy, spread 
        //pizza kunai -> do damage.
      
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            HitEnemy(collision.transform.gameObject);
        }
        if(collision.transform.tag == "Wall")
        {
            if(currWallBounces < 1)
            { 
                Destroy(gameObject);
            }
            currWallBounces--;
        }
    }

    public virtual void Move()
    {
        
    }

    public virtual void spawn(ProjectileStatManager stats, Vector3 _target)
    {
        //transform.LookAt(target);
        rb.GetComponent<Rigidbody>();
        rb.velocity = _target.normalized * speed;
        doMove = true;
    }

    private void Update()
    {
        if(doMove) Move();
    }
}
