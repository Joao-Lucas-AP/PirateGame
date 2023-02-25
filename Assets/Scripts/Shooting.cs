using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;

    public Transform sideFirePoint1, sideFirePoint2, sideFirePoint3;
    public Transform sideFirePoint1L, sideFirePoint2L, sideFirePoint3L;

    public GameObject bulletPrefab;

    public float bulletForce = 20f;
  
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            TripleShotLeft();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            TripleShotRight();
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void TripleShotRight()
    {
        GameObject bullet = Instantiate(bulletPrefab, sideFirePoint1.position, sideFirePoint1.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(sideFirePoint1.up * bulletForce, ForceMode2D.Impulse);

        bullet = Instantiate(bulletPrefab, sideFirePoint2.position, sideFirePoint2.rotation);
        rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(sideFirePoint2.up * bulletForce, ForceMode2D.Impulse);

        bullet = Instantiate(bulletPrefab, sideFirePoint3.position, sideFirePoint3.rotation);
        rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(sideFirePoint3.up * bulletForce, ForceMode2D.Impulse);
    }

    void TripleShotLeft()
    {
        GameObject bullet = Instantiate(bulletPrefab, sideFirePoint1L.position, sideFirePoint1L.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(sideFirePoint1L.up * bulletForce, ForceMode2D.Impulse);

        bullet = Instantiate(bulletPrefab, sideFirePoint2L.position, sideFirePoint2L.rotation);
        rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(sideFirePoint2L.up * bulletForce, ForceMode2D.Impulse);

        bullet = Instantiate(bulletPrefab, sideFirePoint3L.position, sideFirePoint3L.rotation);
        rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(sideFirePoint3L.up * bulletForce, ForceMode2D.Impulse);
    }
}
