using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownController : MonoBehaviour
{
    [SerializeField] private int countdown;
    private PlayerController playerController;
    private UIManager uiManager;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        playerController.enabled = false;
        StartCoroutine(Countdown());
    }
    
    private IEnumerator Countdown()
    {
        while (countdown > 0)
        {
            uiManager.UpdateCountdownText(countdown.ToString());
            yield return new WaitForSeconds(1f);
            countdown--;
        }
        uiManager.UpdateCountdownText("GO!");
        yield return new WaitForSeconds(0.5f);
        uiManager.GetCountdownText().enabled = false;
        playerController.enabled = true;
    }

    public void ResumeCountdownSound()
    {
        GetComponent<AudioSource>().UnPause();
    }

    public void PauseCountdownSound()
    {
        GetComponent<AudioSource>().Pause();
    }
}
