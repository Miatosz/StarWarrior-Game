using System;
using Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{ 
    public class Enemy : MonoBehaviour
    {



    public int health = 100;
    public bool isBoss = false;
    public GameObject deathEffect;
    private GameObject enemy;
    public GameObject player;

    public GameObject bolt;
    public Transform EnemyFirePoint;

    private Vector3 v3 = new Vector3(5, 5, 0);


    private Vector2 movement;
    private float _timeLeft;
    public Rigidbody2D rb;


    float _timer;
    int _waitingTime;
    public Vector3 shipPosition;

    private int speed = 1;
    public bool moveRight = true;
    private Vector3 _startPosition;

    public int direction;
    public double maxDist;
    public double minDist;

    float lockPos = 0;


    private void Start()
    {
      _startPosition = gameObject.transform.position;

      direction = -1;
      maxDist += transform.position.x;
      minDist -= transform.position.x;

    }

    private void Update()
    {

      var enemyPos = Math.Round(transform.position.x);
      var playerPos = Math.Round(player.transform.position.x);

      shipPosition.x = Mathf.Clamp(shipPosition.x, -7.38f, 7.36f);

      transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);

      if (transform.position.y >= 4.9f)
        Repulse(1);

      if (transform.position.y <= -2.5f)
        Repulse(0);

      switch (direction)
      {
        case -1:
          // Moving Left
          if (transform.position.x > minDist)
          {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
          }
          else
          {
            direction = 1;
          }

          break;
        case 1:
          //Moving Right
          if (transform.position.x < maxDist)
          {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
          }
          else
          {
            direction = -1;
          }

          break;
      }

      _timer += Time.deltaTime;
      if (_timer > 0.5)
      {
        if (enemyPos == playerPos)
        {
          if (Random.Range(0, 10) >= 6)
          {
            Instantiate(bolt, EnemyFirePoint.position, EnemyFirePoint.rotation);
          }
        }

        _timer = 0;
      }

    }

    public void Repulse(int i)
    {
      Debug.Log("repulse");
      if (i == 1)
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.x);
      if (i == 0)
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.x);

    }

    public void TakeDamage(int damage)
    {
      health -= damage;
      if (health <= 0)
      {
        Die();
      }
    }

    void Die()
    {
      if (isBoss)
      {
        GetComponent<Enemy>().deathEffect.transform.localScale += v3;

        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

        GetComponent<Enemy>().deathEffect.transform.localScale -= v3;
      }

      Instantiate(deathEffect, transform.position, Quaternion.identity);
      Destroy(gameObject);



      Player.Score += 100;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
      if (other.collider.tag == "Enemy")
      {
        Debug.Log("hit");
        if (direction == 1)
        {
          direction = -1;
          return;
        }

        if (direction == -1)
        {
          direction = 1;
          return;
        }
      }

    }
  }  

}
