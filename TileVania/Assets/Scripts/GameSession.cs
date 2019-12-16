using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    // Text fields
    [SerializeField] Text livesText;
    [SerializeField] Text scoresText;

    private void Awake()
    {
        // Singleton Pattern
        // Only want one of these to exist. Dont let another instantiate.
        // SO when restart scene when player dies the GameSession won't be destroyed when we have to recreate a scene after player dies and restarts scene
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoresText.text = score.ToString();
    }


    public void AddToScore(int amount)
    {
        score += amount;
        scoresText.text = score.ToString();
    }



    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        playerLives -= 1;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F;
    }


    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F;
    }

}
