using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private int sceneCount;
    private int currentLevelIndex = 0;
    private UIManager uiManager;
    private Collectables collectables;
    private int stars;
    private int gems;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        collectables = FindObjectOfType<Collectables>();
        sceneCount = SceneManager.sceneCountInBuildSettings;
        stars = collectables.StarPoints;
        gems = collectables.GemPoints;
    }

    public int GetCurrentLevel()
    {
        return currentLevelIndex + 1;
    }

    public void RestartLevel()
    {
        uiManager.CloseMenu();
        uiManager.CloseTransitionPanel();
        collectables.StarPoints = stars;
        collectables.GemPoints = gems;
        SceneManager.LoadScene(currentLevelIndex);
        uiManager.UpdateStarText(collectables.StarPoints);
        uiManager.UpdateGemText(collectables.GemPoints);
        uiManager.GetCountdownText().enabled = true;
    }

    public void LoadNextLevel()
    {
        stars = collectables.StarPoints;
        gems = collectables.GemPoints;
        uiManager.ToggleTransitionPanel();
        currentLevelIndex = (currentLevelIndex + 1) % sceneCount;
        SceneManager.LoadScene(currentLevelIndex);
        uiManager.GetCountdownText().enabled = true;
    }
}
