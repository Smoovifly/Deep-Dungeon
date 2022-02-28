using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhealth : MonoBehaviour
{

    public int maxhealth = 100;
    public int currentHealth;
   

    public HealthBar healthBar;
    
    void Start()
    {
        currentHealth = maxhealth;
        healthBar.SetMaxHealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (currentHealth <= 0)
        {
            die();
        }
    }

    public void ReceiveHealing(int healingAmount)
    {
        currentHealth += healingAmount;
        if (currentHealth > maxhealth)
        {
            currentHealth = maxhealth;
        }
    }














    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.Sethealth(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bite")
        {
            TakeDamage(20);
        }
        
    }

    void die()
    {
        
    }
}
