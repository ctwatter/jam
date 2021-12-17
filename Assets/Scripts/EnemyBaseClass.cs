using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseClass : MonoBehaviour
{

    //public GameObject gargabePile; // reference to the base

    public int health = 10;
    public int damage = 10;
    public int speed = 1;
    public bool attacking = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DoMovement();
    }



    virtual protected void DoMovement()
    {
    }



    #region Garbage damaging functions
    //OnTriggerEnter on each child

    public void StartAttackingGarbage()
    {
        attacking = true;
        InvokeRepeating("DamageGarbage", 0, 1);
    }

    public void DamageGarbage()
    {
        
        //garbage pile health -= damage;
    }
    #endregion



    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
            //do something like increase score, remove from count, idk
        }
    }
}
