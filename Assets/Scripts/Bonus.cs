using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private UIManager uIManager;
    private Collectables collectables;
    [SerializeField] private int bonus;
    private PlayerController playerController;
    
    private void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
        collectables = FindObjectOfType<Collectables>();
        playerController = FindObjectOfType<PlayerController>();
    }
    
    private void LevelComplete()
    {
        collectables.StarPoints *= bonus;
        collectables.GemPoints *= bonus;
        uIManager.UpdateStarText(collectables.StarPoints);
        uIManager.UpdateGemText(collectables.GemPoints);
        Debug.Log("Bonus : "+collectables.StarPoints);
	    Debug.Log("Diamond Points : "+collectables.GemPoints);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Other Object : "+other.name);
        LevelComplete();
        playerController.enabled = false;
    }
    
}
