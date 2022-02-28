using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy: MonoBehaviour
{

    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;
    private Enemy enemy;
    private Vector3 startingPosition;

    void Start()
    {
        currentHealth = maxHealth;
       
    }

   

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died!");

        animator.SetBool("IsDead", true);

        GetComponent<BoxCollider>().enabled = false;
        this.enabled = false;

       

    }

   
}
