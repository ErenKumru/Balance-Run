using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerObjectTransform;
    private StackController stackController;
    
    [SerializeField] private float yMultiplier;
    [SerializeField] private float zMultiplier;
    [SerializeField] private float smoothTime = 0.125f;
    
    private Vector3 position;
    private float posY,posZ;
    private float distance;

    private void Awake()
    {
        playerObjectTransform = FindObjectOfType<PlayerController>().transform;
        stackController = FindObjectOfType<StackController>();
    }

    private void Start()
    {
        position = transform.position;
        posY = position.y;
        posZ = position.z;
        distance = playerObjectTransform.position.z - transform.position.z;
    }

    private void Update()
    {
        position.z = playerObjectTransform.position.z - distance;
        CameraExtender();
        transform.position = position;
    }

    private void CameraExtender()
    {
        int count = stackController.GetStack().Count;
        float updatedY = posY + count / yMultiplier ;
        float updatedZ = posZ - count / zMultiplier;
        position.z = Mathf.SmoothStep(position.z, updatedZ, smoothTime);
        position.y = Mathf.SmoothStep(position.y, updatedY, smoothTime);
    }
}
