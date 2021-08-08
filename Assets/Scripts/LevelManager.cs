using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private int sceneCount;
    private int currentLevelIndex = 0;
    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        sceneCount = SceneManager.sceneCountInBuildSettings;
    }

    public int GetCurrentLevel()
    {
        return currentLevelIndex + 1;
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(currentLevelIndex);
    }

    public void LoadNextLevel()
    {
        uiManager.ToggleTransitionPanel();
        currentLevelIndex = (currentLevelIndex + 1) % sceneCount;
        SceneManager.LoadScene(currentLevelIndex);
        uiManager.GetCountdownText().enabled = true;
    }
}
