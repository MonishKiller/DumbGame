using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    [Header("DestroyPlayer")]
    [SerializeField] GameObject Hero;
    [SerializeField] levelLoder level;

    //for idel
    [Header("idel")]
    [SerializeField] float idelmovespeed;
    [SerializeField] Vector2 idelMoveDirection;

    //for attack up and down
    [Header("AttackUp&Down")]
    [SerializeField] float attackMoveSpeed;
    [SerializeField] Vector2 attackMoveDirection;

    //for attack player
    [Header("AttackPlayer")]
    [SerializeField] float attackPlayerSpeed;
    [SerializeField] Transform player;
    [SerializeField] Vector2 playerPos;
    private bool hasPlayerPosition=false;

    //other
    [SerializeField] Transform groundCheckUp;
    [SerializeField] Transform groundCheckDown;
    [SerializeField] Transform groundCheckWall;
    [SerializeField] float grouncheckRadius;
    [SerializeField] LayerMask groundLayer;
    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingWall;
    private Rigidbody2D enemyRb;
    private Animator enemyAnim;

    private bool goingup = true;
    private bool facingleft = true;

    private void Start()
    {
        idelMoveDirection.Normalize();
        attackMoveDirection.Normalize();
        enemyRb = this.GetComponent<Rigidbody2D>();
        enemyAnim = this.GetComponent<Animator>();
        level = GameObject.FindGameObjectWithTag("levelLoader").GetComponent<levelLoder>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) {
            Destroy(Hero);
            level.loadCurrentLevel();
             }
    }
    private void Update()
    {
        isTouchingUp = Physics2D.OverlapCircle(groundCheckUp.position, grouncheckRadius, groundLayer);
        Debug.Log(isTouchingUp);
        isTouchingDown = Physics2D.OverlapCircle(groundCheckDown.position, grouncheckRadius, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(groundCheckWall.position, grouncheckRadius, groundLayer);
       

    }

    public void IdelState() {
        if (isTouchingUp && goingup)
            ChangeDirection();
        else if (isTouchingDown && !goingup)
            ChangeDirection();
        if (isTouchingWall)
        {
            if (facingleft)
                Flip();
            else if (!facingleft)
                Flip();
        }
        enemyRb.velocity = idelmovespeed * idelMoveDirection;
    }
    public void AttackUpandDown()
    {
        if (isTouchingUp && goingup)
            ChangeDirection();
        else if (isTouchingDown && !goingup)
            ChangeDirection();
        if (isTouchingWall)
        {
            if (facingleft)
                Flip();
            else if (!facingleft)
                Flip();
        }
        enemyRb.velocity = attackMoveSpeed * attackMoveDirection;
    }
    public void AttackPlayer() {
        if (!hasPlayerPosition) {
            //playerPositon
            playerPos = player.position - transform.position;
            //normalize
            playerPos.Normalize();
            hasPlayerPosition = true;
        }
        if(hasPlayerPosition)
            enemyRb.velocity = playerPos * attackMoveSpeed;
        if (isTouchingDown || isTouchingWall) {
            enemyRb.velocity = Vector2.zero;
            hasPlayerPosition = false;
            enemyAnim.SetTrigger("Slam");
        }

    }
    private void FlipTowardsPlayer() {
        float playerDirection = player.position.x - transform.position.x;
        if (playerDirection > 0 && facingleft)
            Flip();
        else if (playerDirection < 0 && !facingleft)
            Flip();
    }

    private void ChangeDirection() {
        goingup = !goingup;
        idelMoveDirection.y*=-1;
        attackMoveDirection.y*= -1;
    }

    private void Flip() {
        facingleft = !facingleft;
        idelMoveDirection.x *= -1;
        attackMoveDirection.x *= -1;
        transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckUp.position, grouncheckRadius);
        Gizmos.DrawWireSphere(groundCheckDown.position, grouncheckRadius);
        Gizmos.DrawWireSphere(groundCheckWall.position, grouncheckRadius);
    }


}
