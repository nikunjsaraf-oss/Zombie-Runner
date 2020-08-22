using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5;

    NavMeshAgent navMeshAgent;
    float distanceFromTarget = Mathf.Infinity;
    bool isProvoked = false;
    Enemyhealth health;
    Transform target;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<Enemyhealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    private void Update()
    {
               if (health.IsDead())
        {
 
            this.enabled = false;
            navMeshAgent.enabled = false;
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            distanceFromTarget = Vector3.Distance(target.position, transform.position); //calcs the distance between enemy & target
 
            if (isProvoked)
            {
                EngageTarget();
            }
            else if (distanceFromTarget <= chaseRange)
            {
                isProvoked = true;
            }
        }
    }

    private void EngageTarget()
    {
        FaceTarget();
        if(distanceFromTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if(distanceFromTarget <= navMeshAgent.stoppingDistance)
        {

            AttackTarget();
        }
    }

    public void DamageTaken()
    {
        isProvoked = true;
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }


    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
    }


    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }

    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
