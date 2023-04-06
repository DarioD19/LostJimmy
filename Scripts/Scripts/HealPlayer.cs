using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealPlayer : MonoBehaviour
{
    AudioManager audioM;
    [SerializeField] private int _playerHeal;
    [SerializeField] private GameObject _pickupEff;
    HealthManager healthManager;
    private void Start()
    {
      audioM =  FindObjectOfType<AudioManager>();
        healthManager = FindObjectOfType<HealthManager>();

    }
    private void OnTriggerEnter(Collider other)
    {

        
        if (healthManager._currentLife < 5)
        {
            healthManager. HealPlayer(_playerHeal);
            Instantiate(_pickupEff, transform.position, transform.rotation);
            gameObject.SetActive(false);
            audioM.Play("Healing");
        }
        else
        {
            gameObject.SetActive(true);
        }
        
       
       

    }
}
