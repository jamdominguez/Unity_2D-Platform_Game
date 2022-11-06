using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject fruitsContainer;

    private int totalScorePoints;
    private int fruits;

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

        fruits = fruitsContainer.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scorePoints) {
        totalScorePoints += scorePoints;
        fruits--;
        //Debug.Log("scorePoints:" + scorePoints + "  totalScorePoints:" + totalScorePoints);
        Debug.Log("Fruits remains: " + fruits);
        if (fruits <= 0) LevelCompleted();

    }

    public void LevelCompleted() {
        Debug.Log("LevelCompleted");
    }


}
