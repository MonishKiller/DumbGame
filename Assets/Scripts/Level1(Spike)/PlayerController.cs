﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
   
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;
    private float moveInput;    
    private bool facingRight=true;

    
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
		
	}
    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * moveInput, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0) {
            Flip();
        }
        

    }
    void Flip() {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = Vector2.up * jumpForce;
        }
	}
}
