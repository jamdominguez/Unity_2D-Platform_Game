using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    public float horizontalSpeed;
    public string sceneToReload;
    public float groundedRayCastDistance;
    public float fallMultiplier;
    public float lowJumpMultiplier;

    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool canJump;
    private int fruits;

    void Start()
    {
        jumpForce = 3.5f;
        horizontalSpeed = 1.2f;
        sceneToReload = "SampleScene";
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        canJump = false;
        groundedRayCastDistance = 0.05f;
        fallMultiplier = 0.5f;
        lowJumpMultiplier = 1f;

    }

    void Update()
    {
        // Reload game
        if (Input.GetKeyDown(KeyCode.F1)) SceneManager.LoadScene(sceneToReload);

        // Check if is grounded        
        //canJump = Physics2D.Raycast(transform.position, Vector3.down, groundedRayCastDistance) ? true : false;
        // Jump
        if (Input.GetKey(KeyCode.Space) && canJump) Jump();        

        // Horizontal Movement
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //rigidBody2D.velocity = Vector2.right * horizontalSpeed;
            rigidBody2D.velocity = new Vector2(horizontalSpeed, rigidBody2D.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
            if (canJump) animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rigidBody2D.velocity = Vector2.left * horizontalSpeed;
            rigidBody2D.velocity = new Vector2(-horizontalSpeed, rigidBody2D.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            if (canJump) animator.SetBool("isRunning", true);
        }
        else {
            animator.SetBool("isRunning", false);
        }

        
    }

    private void Jump() {
        rigidBody2D.velocity = Vector2.up * jumpForce;
        if (rigidBody2D.velocity.y < 0) rigidBody2D.velocity = Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        if (rigidBody2D.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) rigidBody2D.velocity = Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
        animator.SetTrigger("jump");
        canJump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground") {
            animator.SetTrigger("ground");
            canJump = true;
        }
    }


}
