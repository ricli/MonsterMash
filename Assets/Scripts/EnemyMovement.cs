using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float velocity;
    public float xMax;
    public float yMax;

    Rigidbody2D enemyRB;
    SpriteRenderer enemySprite;
    float moveX;
    float moveY;
    float dir = 1;
    int count = 0;

    // Use this for initialization
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count % 20 == 0)
        {
            moveX = Random.Range(-velocity, velocity);
            moveY = Random.Range(-velocity, velocity);
        }
        if (transform.localPosition.x > xMax)
        {
            moveX = Random.Range(-velocity, 0);
        }
        if (transform.localPosition.x < -xMax)
        {
            moveX = Random.Range(0, velocity);
        }
        if (transform.localPosition.y > yMax)
        {
            moveY = Random.Range(-velocity, 0);
        }
        if (transform.localPosition.y < -yMax)
        {
            moveY = Random.Range(0, velocity);
        }
        if (dir > 0 && moveX < 0)
        {
            enemySprite.flipX = true;
            dir = -1;
        }
        if (dir < 0 && moveX > 0)
        {
            enemySprite.flipX = false;
            dir = 1;
        }
        move();
        count++;
    }

    void move()
    {
        Vector2 movement = new Vector2(moveX, moveY);
        movement *= Time.deltaTime * 8;
        enemyRB.MovePosition(enemyRB.position + movement);
    }
}
