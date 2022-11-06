using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player") {
            Debug.Log("COLLECTED!");
            GetComponent<Animator>().SetTrigger("collected");
        }
        
    }

    public void DestroyFruit() {
        Debug.Log("DESTROY!");
        Destroy(gameObject);
    }
}
