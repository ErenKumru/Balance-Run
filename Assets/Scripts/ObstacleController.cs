using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private StackController stackController;

    private void Awake()
    {
        stackController = FindObjectOfType<StackController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        stackController.RemoveFromStack(other.gameObject);
    }
}
