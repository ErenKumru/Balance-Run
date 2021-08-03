using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackableObjectController : MonoBehaviour
{
    private StackController stackController;
    private bool triggered = false;

    private void Awake()
    {
        stackController = FindObjectOfType<StackController>();
    }

    //Analyze later for bugs and performance
    //1) Add collision layers (in use)
    //2) Add boolean checks (in use)
    private void OnTriggerEnter(Collider other)
    {
        if(!triggered)
        {
            triggered = true;
            stackController.AddToStack(gameObject);
            GetComponent<Collider>().isTrigger = false;
        }
    }
}
