using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public float speed;
    public GameObject explosionVFX;

    private Rigidbody2D rb;
    private Transform playerPos;
    private Player player;

    public int enemyHealth;
    public GameObject hpText;

    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    public float bulletForce = 20f;
    float fireRate = 1f;
    float nextFireTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        //TEST
        float distanceFromPlayer = Vector2.Distance(playerPos.position, transform.position);
        if (distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }
        else if(distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
        //TEST


        hpText.GetComponent<UnityEngine.UI.Text>().text = enemyHealth.ToString();

        //transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        Vector2 direction = playerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;

        if (enemyHealth <= 0)
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
