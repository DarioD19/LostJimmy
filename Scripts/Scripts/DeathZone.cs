using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public int damageToGive = 1;
    public PlayerMovment thePlayer;
    private Vector3 respawnPoint;
    
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, respawnPoint);
        }
    }
}
