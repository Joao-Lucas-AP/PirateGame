using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject gamePlayScreen;
    public GameObject gameOverScreen;

    public Text scoreText;

    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);

        PlayerPrefs.SetInt("Score", 0);
    }
}
