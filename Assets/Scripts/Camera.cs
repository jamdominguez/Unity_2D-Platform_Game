using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject player;
    public bool follow;

    private static float LEFT_LIMIT = 1.29f;
    private static float RIGHT_LIMIT = 4.85f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (follow) {
            Vector3 position = transform.position;
            // Check limits
            float playerPositionX = player.transform.position.x;
            if (playerPositionX <= LEFT_LIMIT) position.x = LEFT_LIMIT;
            else if (playerPositionX >= RIGHT_LIMIT) position.x = RIGHT_LIMIT;
            else position.x = playerPositionX;

            transform.position = position;
        } 
    }
}
