using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTimeControl : MonoBehaviour
{
    public Text spawnText;
    public Slider spawnTimeSlider;

    void Start()
    {
        spawnTimeSlider.maxValue = 6;
        spawnTimeSlider.minValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        spawnText.text = spawnTimeSlider.value.ToString("0");

        PlayerPrefs.SetFloat("spawnTime", spawnTimeSlider.value);
    }
}
