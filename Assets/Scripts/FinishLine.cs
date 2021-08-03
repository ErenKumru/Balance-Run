using System;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private StackController stackController;

    private void Awake()
    {
        stackController = FindObjectOfType<StackController>();
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
    }
}