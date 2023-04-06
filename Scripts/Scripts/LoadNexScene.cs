using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNexScene : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneBuildIndex + 1);
        }
    }
   

}
