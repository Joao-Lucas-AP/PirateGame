using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject gamePlayScene;
    public GameObject menuScene;
    public GameObject gameOverScene;
    public GameObject victoryScene;

    public GameObject pauseMenu;

    void Start()
    {
        victoryScene.SetActive(false);
        gameOverScene.SetActive(false);
        optionsMenu.SetActive(false);
        gamePlayScene.SetActive(false);
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }
    public void ContinueButton()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    public void PlayButton()
    {
        gamePlayScene.SetActive(true);
        menuScene.GetComponent<Canvas>().enabled = false;
    }

    public void OptionsMenu()
    {
        optionsMenu.SetActive(true);
    }

    public void ExitOptions()
    {
        optionsMenu.SetActive(false);
    }
}
