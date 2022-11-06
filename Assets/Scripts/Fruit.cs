using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int scorePoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player") {
            GetComponent<Animator>().SetTrigger("collected");
            GameManager.gameManager.UpdateScore(scorePoints);
        }
    }

    public void DestroyFruit() {
        Destroy(gameObject);
    }
}
