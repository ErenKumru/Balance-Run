using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [Header("Managers")]
    private LevelManager levelManager;
    private UIManager uIManager;

    [Header("Gameplay - UI Elements")]
    private Transform finishLine;
    private Transform spawnPoint;
    private Transform playerCharacterTransform;

    private float levelLength;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        finishLine = FindObjectOfType<FinishLine>().transform;
        spawnPoint = FindObjectOfType<StackController>().transform;
        playerCharacterTransform = FindObjectOfType<PlayerController>().transform;
        uIManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uIManager.ShowLevel(levelManager.GetCurrentLevel());
        CalculateLevelLength();
    }

    private void Update()
    {
        UpdateSliderValue();
    }

    private void CalculateLevelLength()
    {
        levelLength = finishLine.position.z - spawnPoint.position.z;
    }

    private void UpdateSliderValue()
    {
        float distanceTravelled = playerCharacterTransform.position.z - spawnPoint.position.z;
        float levelCompleteRatio = Mathf.Clamp01(distanceTravelled / levelLength);
        uIManager.UpdateSlider(levelCompleteRatio);
    }
}
