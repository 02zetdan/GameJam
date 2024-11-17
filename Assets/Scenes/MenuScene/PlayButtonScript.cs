using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    public GameObject audioManager;
    // Start is called before the first frame update
    public void Play()
    {
        audioManager = GameObject.Find("AudioManager");
        StartCoroutine(NextSceneCoroutine());
    }

    IEnumerator NextSceneCoroutine()
    {
        //Print the time of when the function is first called.
        audioManager.GetComponent<AudioManager>().Play("Play");
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        //After we have waited 5 seconds print the time again.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
