using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpSpeed;
    public float horizontalSpeed;    
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public int hp;

    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool canJump;
    private bool isDead;
    private Vector2 lastCheckPointTaked;

    void Start()
    {        
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        canJump = false;
        //isDead = false;
        lastCheckPointTaked = transform.position;
    }

    void Update()
    {
        if (/*!isDead &&*/ !LevelManager.levelManager.IsLevelCompleted()) CheckMovement();
    }

    private void CheckMovement() {
        // Jump
        if (Input.GetKey(KeyCode.Space) && canJump) Jump();
        //CheckJumpType();

        // Horizontal Movement
        if (Input.GetKey(KeyCode.RightArrow)) MoveRight();
        else if (Input.GetKey(KeyCode.LeftArrow)) MoveLeft();
        else animator.SetBool("isRunning", false);        
    }

    private void MoveRight() {
        rigidBody2D.velocity = new Vector2(horizontalSpeed, rigidBody2D.velocity.y);
        spriteRenderer.flipX = false;
        if (canJump) animator.SetBool("isRunning", true);
    }

    private void MoveLeft() {
        rigidBody2D.velocity = new Vector2(-horizontalSpeed, rigidBody2D.velocity.y);
        spriteRenderer.flipX = true;
        if (canJump) animator.SetBool("isRunning", true);
    }

    private void Jump() {
        rigidBody2D.velocity = Vector2.up * jumpSpeed;
        animator.SetTrigger("jump");
        GetComponent<AudioSource>().Play();
        canJump = false;
    }

    private void CheckJumpType() {
        if (rigidBody2D.velocity.y < 0) rigidBody2D.velocity = Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        if (rigidBody2D.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) rigidBody2D.velocity = Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
    }

    public void Hurt(int damage) {
        //Debug.Log("Hurt with damage:" + damage);
        hp -= damage;
        animator.SetTrigger("hurt");
        if (hp <= 0)
        {
            //isDead = true;
            //Debug.Log("Player DEAD!");
            //Destroy(gameObject, 0.5f);
            //spriteRenderer.enabled = false;
            transform.position = lastCheckPointTaked;//LevelManager.levelManager.ReloadLevel();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground") {
            animator.SetTrigger("ground");
            canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "CheckPoint") {            
            collision.gameObject.GetComponent<CheckPoint>().Take();
            lastCheckPointTaked = collision.gameObject.transform.position;
        }   
    }
}
