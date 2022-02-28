using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float LookRadius = 10f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public Animator animator;
    public GameObject Mouth;
    

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius);
    }


    void Die()
    {

    }

}

