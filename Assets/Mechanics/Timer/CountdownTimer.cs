using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.ShaderGraph.Internal;

public class CountdownTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI cdtext;
    public GameObject endResultManager;
    public float startTime;
    private float currentTime;
<<<<<<< HEAD
    void Start()
    {
        cdtext = GetComponent<TextMeshProUGUI>();
        startTime = 10f;
=======
    private bool hasMusicChanged = false;
    void Start()
    {
        cdtext = GetComponent<TextMeshProUGUI>();
        startTime = 65f;
>>>>>>> fa97b7d (Fix Background Music)
        currentTime = startTime;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;
            OnTimerEnd();
        }
        if (currentTime <= 60 && !hasMusicChanged)
        {
            cdtext.color = Color.red;
            OnTriggerIntense();
            hasMusicChanged = true;
        }
        int minutes = Mathf.FloorToInt(currentTime / 60); // Total minutes left
        int seconds = Mathf.FloorToInt(currentTime % 60); // Remaining seconds in the current minute

        cdtext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void OnTimerEnd()
    {
<<<<<<< HEAD
        endResultManager.GetComponent<EndResultManager>().showWinner();
=======
        endResultManager.showWinner();
        FindObjectOfType<AudioManager>().Stop("Intense Background Music");
>>>>>>> fa97b7d (Fix Background Music)
        enabled = false;
    }
    private void OnTriggerIntense()
    {

        FindObjectOfType<AudioManager>().Stop("Background Music");
        FindObjectOfType<AudioManager>().Play("Intense Background Music");
    }
}
