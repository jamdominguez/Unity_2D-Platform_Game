using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float jumpVelocity;
    public float horizontalSpeed;
    public string sceneToReload;
    public float fallMultiplier;
    public float lowJumpMultiplier;

    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool canJump;
    private int fruits;

    void Start()
    {
        jumpVelocity = 3.5f;
        horizontalSpeed = 1.2f;
        sceneToReload = "SampleScene";
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        canJump = false;
        fallMultiplier = 0.5f;
        lowJumpMultiplier = 1f;

    }

    void Update()
    {
        // Reload game
        if (Input.GetKeyDown(KeyCode.F1)) SceneManager.LoadScene(sceneToReload);

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
        rigidBody2D.velocity = Vector2.up * jumpVelocity;
        animator.SetTrigger("jump");
        canJump = false;
    }

    private void CheckJumpType() {
        if (rigidBody2D.velocity.y < 0) rigidBody2D.velocity = Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        if (rigidBody2D.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) rigidBody2D.velocity = Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
    }

    public void Hurt(int damage) {
        Debug.Log("Hurt with damage:" + damage);
        animator.SetTrigger("hurt");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground") {
            animator.SetTrigger("ground");
            canJump = true;
        }
    }
}
