using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private int currentLevelIndex = 0;

    private void Start()
    {
        Debug.Log("startIndex: " + currentLevelIndex);
    }

    public int GetCurrentLevel()
    {
        return currentLevelIndex + 1;
    }

    public void LoadCurrentLevel()
    {
        Debug.Log("currentLevelIndex: " + currentLevelIndex);
        SceneManager.LoadScene(currentLevelIndex);
    }

    public void LoadNextLevel()
    {
        Debug.Log("currentLevelIndex " + currentLevelIndex);
        currentLevelIndex++;
        Debug.Log("next level index: " + currentLevelIndex);
        SceneManager.LoadScene(currentLevelIndex);
    }
}
