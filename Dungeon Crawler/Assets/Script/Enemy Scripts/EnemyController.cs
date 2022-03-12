using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float LookRadius = 10f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    float iDiedAtTime = 0f;
    public Animator animator;
    public GameObject Mouth;
    public GameObject Spider;



    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public void activateBite()
    {
        Mouth.GetComponent<Collider>().enabled = true;
    }
    public void deactivateBite()
    {
        Mouth.GetComponent<Collider>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(currentHealth > 0)
        {
            float distance = Vector3.Distance(target.position, transform.position);

            if(distance <= LookRadius)
            {
                agent.SetDestination(target.position);
                animator.SetBool("IsWalking", true);

                if(agent.remainingDistance < 1.5f)
                {
                    GetComponent<Animator>().SetTrigger("Attack");
                }
            }

            if (Time.time >= nextAttackTime)
            {
                if (Mouth.GetComponent<Collider>().enabled == true)
                {
                    activateBite();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
        else
        {
            if(iDiedAtTime > 0 && Time.time >= iDiedAtTime)
            {
                //do something now that i'm dead...
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius);
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
        Debug.Log($"{this.name} Died!");

        animator.SetBool("IsDead", true);
        GetComponent<BoxCollider>().enabled = false;
        this.enabled = false;

        //Destroy(agent);
        //Destroy(Mouth);
        Destroy(Spider, 5.0f);
        //Destroy(myself);
        //myself.enabled = false;

       
        //this.enabled = false;
       
       // iDiedAtTime = Time.time + 5f;
        //agent.SetDestination(transform.position );
        
        
       

    }

}

