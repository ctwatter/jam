using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEnemy : EnemyBaseClass
{
    MouseEnemy()
    {
        
        health = 10;
        damage = 10;
        speed  = 1;
        attacking = false;
    }

    float pingPong;
    Vector2 pos;
    float frequency = 2.0f; // Speed of sine movement
    float magnitude = 0.5f;


    private void Start() 
    {
        pos = transform.position;
    }

    private void Update() 
    {
        DoMovement();
    }

    protected override void DoMovement()
    {
        if(attacking == true) return;

        // straight movement
        // transform.Translate(Vector2.down * speed * Time.deltaTime);

        //zig zag motion
         pos += Vector2.down * Time.deltaTime * speed;
         transform.position = pos + Vector2.left * Mathf.Sin(Time.time * frequency) * magnitude;
        
    }

    void OnTriggerEnter(Collider other) 
    {
        //if hits garbage collider
        //stop moving
        Debug.Log("enter");
        if(other.gameObject.tag == "Garbage") StartAttackingGarbage();
    }
}
