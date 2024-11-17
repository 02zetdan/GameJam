using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButtonScript : MonoBehaviour
{
    public GameObject audioManager;
    public void Quit()
    {
        StartCoroutine(QuitCoroutine());

    }



    IEnumerator QuitCoroutine()
    {
        //Print the time of when the function is first called.
        audioManager.GetComponent<AudioManager>().Play("Quit");
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.75f);

        //After we have waited 5 seconds print the time again.
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
