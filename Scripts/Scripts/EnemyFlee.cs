using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFlee : MonoBehaviour
{
    [SerializeField] private float _fleeRadius;
    Transform target;
    NavMeshAgent agent;
    Animator animator;
    [SerializeField] private float _fleeSpeed;
    [SerializeField] private GameObject _healingCapsule;
    private bool _disableMovment = false;
    [SerializeField] private GameObject _deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance._player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!_disableMovment)
        {
            EnemyMove();
            
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PlayDeathAnim());
        }
    }
    public void EnemyMove()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= _fleeRadius)
        {

            Vector3 direction = -(target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
           
            agent.Move( direction * _fleeSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            

            animator.SetBool("IsRuning", true);
        }
        if (distance > _fleeRadius)
        {
            agent.isStopped = true;
            animator.SetBool("IsRuning", false);
        }
        
           
        
    }
    IEnumerator PlayDeathAnim()
    {
        
        _disableMovment = true;
        
        animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(2f);
        Instantiate(_deathEffect, transform.position + new Vector3(0, 1f, 0), transform.rotation);
        yield return null;
        Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("SlimeDeath");
        Instantiate(_healingCapsule, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
        
        
       
        

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _fleeRadius);
    }
     
    
    
}
