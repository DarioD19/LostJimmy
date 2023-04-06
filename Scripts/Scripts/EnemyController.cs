using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float _lookRadius;
    [SerializeField] private float _attackRange;
    Transform target;
    NavMeshAgent agent;
    Animator _animator;
    private void Start()
    {
        target = PlayerManager.instance._player.transform;
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= _lookRadius)
        {
            agent.SetDestination(target.position);
            FindObjectOfType<PlayerMovment>();
            
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
           
        }
        if (distance <= _attackRange)
        {
            _animator.SetBool("IsAttacking", true);
            FindObjectOfType<AudioManager>().Play("Enemy");
        }
        else
        {
            _animator.SetBool("IsAttacking", false);
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _lookRadius);
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}
