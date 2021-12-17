using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollyPolly : Projectile
{
    public int maxRicochet = 0;
    public int currRicochets = 0;
    public float damage = 10;

    public float ricochetRadius;

    public List<GameObject> hitEnemies;


    public override void HitEnemy(GameObject enemy)
    {
        //enemy.takeDamage(damage);
        hitEnemies.Add(enemy);
        if (currRicochets > 0)
        {
            currRicochets--;
            Collider[] hits = Physics.OverlapSphere(gameObject.transform.position, ricochetRadius);
            if(hits.Length > 0)
            {
                target = Vector3.negativeInfinity;
                foreach(Collider c in hits)
                {
                    if (hitEnemies.Contains(c.gameObject))
                        continue;
                    else
                    {
                        target = c.gameObject.transform.position;
                        break;
                    }
                }
                if(target == Vector3.negativeInfinity)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public override void spawn(ProjectileStatManager stats,Vector3 _target)
    {
        
        speed = stats.rollySpeed;
        maxRicochet = stats.rollyRicochets;
        currRicochets = maxRicochet;
        damage = stats.rollyDamage;
        currWallBounces = stats.rollyWallBounces;
        base.spawn(stats, _target);
    }


}
