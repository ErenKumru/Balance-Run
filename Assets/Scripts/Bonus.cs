using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private UIManager uIManager;
    private Collectables collectables;
    [SerializeField] private int bonus;

    private void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
        collectables = FindObjectOfType<Collectables>();
    }

    private void LevelComplete()
    {
        collectables.StarPoints *= bonus;
        uIManager.UpdateStarText(collectables.StarPoints);
        Debug.Log("Bonus : "+collectables.StarPoints);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Other Object : "+other.name);
        LevelComplete();
    }
}
