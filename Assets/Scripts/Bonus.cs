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
    private StackController stackController;
    private int stars;
    private int gems;
    
    private void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
        collectables = FindObjectOfType<Collectables>();
        playerController = FindObjectOfType<PlayerController>();
        stackController = FindObjectOfType<StackController>();
    }

    private void Start()
    {
        stars = collectables.StarPoints;
        gems = collectables.GemPoints;
    }

    private void LevelComplete()
    {
        stars = (collectables.StarPoints - stars) * bonus;
        gems = (collectables.GemPoints - gems) * bonus;
        collectables.StarPoints += stars;
        collectables.GemPoints += gems;
        uIManager.UpdateStarText(collectables.StarPoints);
        uIManager.UpdateGemText(collectables.GemPoints);
    }

    private void OnTriggerEnter(Collider other)
    {
        LevelComplete();
        playerController.enabled = false;
        AnimatorControl();
        StartCoroutine(DelayTransitionPanel());
    }

    private void AnimatorControl()
    {
        Quaternion rotation = playerController.transform.rotation;
        rotation.y = 180;
        playerController.transform.rotation = rotation;
        Animator animator = playerController.GetComponent<Animator>();
        animator.SetBool("isFinished",true);
        List<GameObject> stack = stackController.GetStack();
        foreach (GameObject stackable in stack)
        {
            rotation = stackable.transform.rotation;
            rotation.y = 180;
            stackable.transform.rotation = rotation;
            animator = stackable.GetComponent<Animator>();
            animator.SetBool("isFinished",true);
        }
    }

    private IEnumerator DelayTransitionPanel()
    {
        yield return new WaitForSeconds(1f);
        uIManager.ToggleTransitionPanel();
    }
}
