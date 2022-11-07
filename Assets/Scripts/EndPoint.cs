using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void MakeVisible() {
        Debug.Log("End visible");
        spriteRenderer.enabled = true;
    }

    public void ProcessAfterCompleted() {        
        LevelManager.levelManager.LoadNextLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && LevelManager.levelManager.IsAllFruitsCollected())
        {
            GetComponent<Animator>().SetTrigger("take");
            LevelManager.levelManager.LevelCompleted();
        }
    }   
        
}
