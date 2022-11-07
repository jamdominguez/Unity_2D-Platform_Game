using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    public GameObject fruitsContainer;
    public GameObject endPoint;
    public AudioClip winsAudiClip;


    private int totalScorePoints;
    private int fruits;
    private bool isLevelCompleted = false;
    private bool isGamePaused;
    private Scene currentScene;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        /*
        if (levelManager == null)
        {
            levelManager = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }*/

        if (levelManager == null) levelManager = this;

        fruits = fruitsContainer.transform.childCount;
        currentScene = SceneManager.GetActiveScene();
        audioSource = GetComponent<AudioSource>();
        ResumeGame();

        //Debug.Log("LevelManager - fruits: " + fruits + "  sceneName: " + currentScene.name + "  sceneIndex: " + currentScene.buildIndex);
        //Debug.Log(GetComponent<AudioSource>().clip);
    }

    // Update is called once per frame
    void Update()
    {
        // Reload game
        if (Input.GetKeyDown(KeyCode.F1)) SceneManager.LoadScene("Level1");
        if (Input.GetKeyDown(KeyCode.F2)) SceneManager.LoadScene("Level2");
        if (Input.GetKeyDown(KeyCode.F3)) SceneManager.LoadScene("Level3");
        if (Input.GetKeyDown(KeyCode.F4)) SceneManager.LoadScene("Level4");

        //if (Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene(currentScene.buildIndex + 1);

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!isGamePaused) PauseGame();
            else ResumeGame();
        }
        
        currentScene = SceneManager.GetActiveScene();
    }

    public void UpdateScore(int scorePoints) {
        totalScorePoints += scorePoints;
        fruits--;
        //Debug.Log("scorePoints:" + scorePoints + "  totalScorePoints:" + totalScorePoints);
        Debug.Log("Fruits remains: " + fruits);
        if (fruits <= 0) endPoint.GetComponent<EndPoint>().MakeVisible();

    }

    public void LoadNextLevel() {
        Debug.Log("Loading next level");
        if (currentScene.buildIndex + 1 < 4) { // 4 Levels (FIXME)
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        } else {
            audioSource.Stop();
            GetComponent<AudioSource>().clip = winsAudiClip;
            audioSource.Play();
        }
    }

    public void ReloadLevel() {
        Debug.Log("Reloading level");
        SceneManager.LoadScene(currentScene.name);
    }

    public bool IsAllFruitsCollected() {
        return fruits <= 0;
    }

    public void LevelCompleted() {
        Debug.Log("LevelCompleted");
        isLevelCompleted = true;
    }

    public bool IsLevelCompleted() {
        return isLevelCompleted;
    }

    public void PauseGame() {
        isGamePaused = true;
        GetComponent<SpriteRenderer>().enabled = true;
        Time.timeScale = 0;
    }

    public void ResumeGame() {
        isGamePaused = false;
        GetComponent<SpriteRenderer>().enabled = false;
        Time.timeScale = 1;
    }


}
