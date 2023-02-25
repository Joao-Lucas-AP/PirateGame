using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionTimeControl : MonoBehaviour
{
    public Text timeText;
    public Slider sessionTimeSlider;

    void Start()
    {
        sessionTimeSlider.maxValue = 180;
        sessionTimeSlider.minValue = 60;
    }

    // Update is called once per frame
    void Update()
    {
        int minutes = Mathf.FloorToInt(sessionTimeSlider.value / 60);
        int seconds = Mathf.FloorToInt(sessionTimeSlider.value - minutes * 60);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        timeText.text = textTime;

        PlayerPrefs.SetFloat("sliderValue", sessionTimeSlider.value);
    }
}
