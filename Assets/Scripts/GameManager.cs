using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    private int totalScorePoints;

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

    public void updateScore(int scorePoints) {
        totalScorePoints += scorePoints;
        Debug.Log("scorePoints:" + scorePoints + "  totalScorePoints:" + totalScorePoints);
    }


}
