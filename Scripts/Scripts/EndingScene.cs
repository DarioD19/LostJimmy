using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }
}
