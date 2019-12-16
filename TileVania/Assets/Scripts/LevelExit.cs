using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float waitToLoad = 2f;
    [SerializeField] float levelExitSlowMotion = 0.2f;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        // Smooth slowmo
        Time.timeScale = levelExitSlowMotion;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;

        yield return new WaitForSecondsRealtime(waitToLoad);
        // Slowmo gone when next level starts up
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F;


        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }



}
