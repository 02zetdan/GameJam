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
    public float startTime = 10f;
    private float currentTime; 
    void Start()
    {
        cdtext = GetComponent<TextMeshProUGUI>();
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            currentTime = 0;
        }
        if (currentTime <= 30)
        {
            cdtext.color = Color.red;
        }
        cdtext.text = currentTime.ToString("F0");
    }
}
