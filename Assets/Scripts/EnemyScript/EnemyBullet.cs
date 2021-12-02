﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private const int BULLET_DAMAGE = 10;
    private const float BULLET_SPEED = 2f;
    private Vector3 bulletDirection;
    private GameObject player;
    private Rigidbody2D enemyBullet;
    private GameObject UIDisplay;
    private UIBoss UIBoss;

    void Start()
    {
        player = GameObject.Find("Player");
        if (player != null)
        {
            bulletDirection = player.transform.position;
        }
        enemyBullet = gameObject.GetComponent<Rigidbody2D>();
        UIDisplay = GameObject.Find("UIDisplay");
        UIBoss = UIDisplay.GetComponent<UIBoss>();
    }

    void Update()
    {
        enemyBullet.velocity = bulletDirection * BULLET_SPEED;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().takeDamage(BULLET_DAMAGE);
            UIBoss.enableUI();
            Destroy(gameObject);
        }
    }
}