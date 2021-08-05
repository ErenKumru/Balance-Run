using System;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private StackController stackController;
    private ParticleSystem[] confettis;

    private void Awake()
    {
        stackController = FindObjectOfType<StackController>();
        confettis = FindObjectsOfType<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Other Object : "+other.name);
        List<GameObject> stack = stackController.GetStack();
        int count = stack.Count;
        for (int i = 0; i < count-1; i++)
        {
            stack[i].GetComponent<Collider>().enabled = false;
        }
        foreach (ParticleSystem confetti in confettis)
        {
            confetti.Play();
        }
        
    }
}