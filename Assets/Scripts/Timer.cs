using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public Text timerText;
    float gameTime;

    public GameObject victoryScreen;
    public GameObject gamePlayScreen;

    private bool stopTimer;

    void Start()
    {
        gameTime = PlayerPrefs.GetFloat("sliderValue");

        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    void Update()
    {
        float time = gameTime - Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if(time <= 0)
        {
            stopTimer = true;
        }

        if(stopTimer == true)
        {
            victoryScreen.SetActive(true);
            gamePlayScreen.SetActive(false);
        }

        if(stopTimer == false)
        {
            timerText.text = textTime;
            timerSlider.value = time;
        }
    }
}
