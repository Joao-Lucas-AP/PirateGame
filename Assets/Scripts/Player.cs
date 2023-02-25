using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Speed values")]
    public float speed;
    public float rotationSpeed;
    
    public GameObject healthText;
    public int score;
    public GameObject scorepoint;

    public GameObject gameOverScreen;
    public GameObject gamePlayScreen;

    float move;
    float rotation;

    public int Health = 5;

    void Start()
    {

    }

    void Update()
    {
        scorepoint.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        healthText.GetComponent<UnityEngine.UI.Text>().text = Health.ToString();

        PlayerPrefs.SetInt("Score", score);

        move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") * -rotationSpeed * Time.deltaTime;
        
        if (Health <= 0)
        {
            gameOverScreen.SetActive(true);
            gamePlayScreen.SetActive(false);
        }
    }
   void LateUpdate()
    {
        transform.Translate(0f, move, 0f);
        transform.Rotate(0f, 0f, rotation);
    }
}
