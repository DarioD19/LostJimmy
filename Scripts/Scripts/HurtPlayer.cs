using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive = 1;
    private HealthManager healtMan;
    private void Start()
    {
       healtMan = FindObjectOfType<HealthManager>();
    }

    private void OnTriggerEnter(Collider other)
        
    {
        if (other.CompareTag("Player"))
        {

            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, hitDirection);
        }
    }
}
