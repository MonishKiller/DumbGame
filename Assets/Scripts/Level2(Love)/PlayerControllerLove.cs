using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLove : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private DeathStand DS;

    private Rigidbody2D rb;
    private float moveInput;
    private bool facingRight = true;


    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        DS = GameObject.FindGameObjectWithTag("DS").GetComponent<DeathStand>();

    }
    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        if(DS.playerIn==false)
            rb.velocity = new Vector2(speed * moveInput, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }


    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
