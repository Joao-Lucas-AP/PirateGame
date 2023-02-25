using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject explosionVFX;

    private Rigidbody2D rb;
    private Transform playerPos;
    private Player player;

    public int enemyHealth;
    public GameObject hpText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }  
    void Update()
    {
        hpText.GetComponent<UnityEngine.UI.Text>().text = enemyHealth.ToString();

        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        Vector2 direction = playerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;

        if(enemyHealth <= 0)
        {
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            player.score++;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            player.Health--;
            Debug.Log(player.Health);
            Destroy(gameObject);
        }
        if (other.CompareTag("Bullet"))
        {           
            enemyHealth--;
        }
    }
}
