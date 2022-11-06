using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player") {
            GetComponent<Animator>().SetTrigger("collected");
            GameManager.gameManager.updateScore(gameObject.name);
        }
    }

    public void DestroyFruit() {
        Destroy(gameObject);
    }
}
