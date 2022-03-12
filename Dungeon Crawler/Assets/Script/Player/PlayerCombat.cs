using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Transform attackpoint;
    public float attackRange = 0.5f;
    public int attackDamage = 35;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttackTime = 0f;


    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            { 
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;

            }
        }
       


    }

    void Attack()
    {
       Collider[] hitEnemies = Physics.OverlapSphere(attackpoint.position, attackRange, enemyLayers);


        foreach(Collider enemy in hitEnemies)
        {
            enemy?.GetComponent<EnemyController>()?.TakeDamage(attackDamage);
        }

    }

    private void OnDrawGizmosSelected()
    {

        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}



