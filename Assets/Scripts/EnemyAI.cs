using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5;

    NavMeshAgent navMeshAgent;
    float distanceFromTarget = Mathf.Infinity;
    bool isProvoked = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distanceFromTarget = Vector3.Distance(target.position, transform.position);
        
        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distanceFromTarget <= chaseRange)
        {
            isProvoked = true;
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
        Gizmos.color = new Color(255, 255, 255, 1f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
