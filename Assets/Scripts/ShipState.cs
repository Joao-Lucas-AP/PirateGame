using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipState : MonoBehaviour
{
    public Sprite shipDamaged1;
    public Sprite shipDamaged2;

    private Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        if (player.Health <= 3)
        {
            GetComponent<SpriteRenderer>().sprite = shipDamaged1;
        }
        if (player.Health <= 1)
        {
            GetComponent<SpriteRenderer>().sprite = shipDamaged2;
        }

    }
}
