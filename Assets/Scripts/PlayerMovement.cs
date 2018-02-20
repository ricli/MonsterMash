using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Rigidbody2D playerRB;
    SpriteRenderer playerSprite;
    float moveX;
    float moveY;
    float dir = 1;

	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        if (dir > 0 && moveX < 0)
        {
            playerSprite.flipX = true;
            dir = -1;
        }
        if (dir < 0 && moveX > 0)
        {
            playerSprite.flipX = false;
            dir = 1;
        }
        move();
	}

    void move()
    {
        Vector2 movement = new Vector2(moveX, moveY);
        movement *= Time.deltaTime * 8;
        playerRB.MovePosition(playerRB.position + movement);
    }
}
