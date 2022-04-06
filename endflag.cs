using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endflag : MonoBehaviour
{


    public string nextSceneName;
    public bool lastLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lastLevel == true)
            {
                SceneManager.LoadScene(0);
                //To-do: Go back to the menu scene.
            }
            else
            {
                SceneManager.LoadScene(nextSceneName);
                //To-do: Move on to the next level.
            }
        }
    }
}