using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputManager inputManager;
    private StackController stackController;
    private Collider playerCollider;
    [SerializeField] private float speed;
    [SerializeField] private float maxDistance = 2.0f;
    [SerializeField] private float smoothTime;
    [SerializeField] private float inputScale;
    private float velocity;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        stackController = FindObjectOfType<StackController>();
        playerCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        ConstantForwardMovement();
        SideMovement();
    }

    private void ConstantForwardMovement()
    {
        //Better Performance: Multiply Vector last to not multiply all values of Vector repeatedly - multiplying last only multiplies Vector values once.
        transform.position += speed * Time.deltaTime * Vector3.forward;
    }

    //Side movement by swiping
    private void SideMovement()
    {
        Vector3 newPosition;
        newPosition = transform.position;
        newPosition.x = Mathf.SmoothDamp(newPosition.x, newPosition.x + inputManager.input / inputScale, ref velocity, smoothTime);
        newPosition.x = Mathf.Clamp(newPosition.x, -maxDistance, maxDistance);
        transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (stackController.GetStack().Any())
        {
            stackController.RemoveFromStack(stackController.GetStack()[0]);
        }
        playerCollider.isTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerCollider.isTrigger = false;
    }
}
