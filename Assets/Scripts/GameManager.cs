using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(string fruitName) {
        switch (fruitName) {
            case "Apple": score += 1;
                break;
            case "Pinapple": score += 2;
                break;
            case "Melon": score += 3;
                break;
            default: Debug.LogError("Fruit not recognized!!, possible error");
                break;
        }
        Debug.Log("score:" + score);
    }


}
