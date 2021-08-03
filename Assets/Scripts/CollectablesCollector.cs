using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesCollector : MonoBehaviour
{
    private UIManager uIManager;
    private Collectables collectables;
    [SerializeField] private Collectable collectableItems;

    private void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
        collectables = FindObjectOfType<Collectables>();
    }

    private void Update()
    {
        transform.Rotate(90*Time.deltaTime,0,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        CollectItem();
    }

    private void CollectItem()
    {
        gameObject.SetActive(false);

        switch (collectableItems)
        {
            case Collectable.Star:
                collectables.StarPoints++;
                uIManager.UpdateStarText(collectables.StarPoints);
                break;
            case Collectable.Gem:
                collectables.GemPoints++;
                uIManager.UpdateGemText(collectables.GemPoints);
                break;
        }
    }

    private enum Collectable
    {
        Star,
        Gem
    }
}
