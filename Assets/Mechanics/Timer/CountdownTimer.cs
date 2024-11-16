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
    public EndResultManager endResultManager;
    public float startTime;
    private float currentTime; 
    void Start()
    {
        cdtext = GetComponent<TextMeshProUGUI>();
        startTime = 1f;
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
        if (currentTime <= 60)
        {
            cdtext.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(currentTime / 60); // Total minutes left
        int seconds = Mathf.FloorToInt(currentTime % 60); // Remaining seconds in the current minute

        cdtext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void OnTimerEnd()
    {
        endResultManager.showWinner();
        enabled = false;
    }
    private void OnTriggerIntense()
    {

        FindObjectOfType<AudioManager>().Stop("Background Music");
        FindObjectOfType<AudioManager>().Play("Background Music");
    }
