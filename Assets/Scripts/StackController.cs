using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    private Transform playerCharacterTransform;
    [SerializeField] private float yOffset = 0f;
    [SerializeField] private float maxDistanceMultiplier = 0.4f;
    [SerializeField] private float followSpeedMultiplier = 1f;

    private List<GameObject> stack = new List<GameObject>(); //learn why adding readonly is suggested
    private int count = 0;
    private Coroutine followPlayerCoroutine;

    private void Awake()
    {
        playerCharacterTransform = FindObjectOfType<PlayerController>().transform;
    }

    public void AddToStack(GameObject objectToStack)
    {
        if(!stack.Contains(objectToStack))
        {
            stack.Add(objectToStack);
            SetLocalPosition(objectToStack.transform);
            count++;

            if (count == 1) followPlayerCoroutine = StartCoroutine(FollowPlayer());
        }
    }

    private void SetLocalPosition(Transform objectToSetTransform)
    {
        objectToSetTransform.SetParent(transform);
        Vector3 localPosition = count > 0 ? stack[count - 1].transform.localPosition : playerCharacterTransform.localPosition;
        localPosition.y += yOffset;
        objectToSetTransform.localPosition = localPosition;
    }

    //Try to improve and refactor
    public void RemoveFromStack(GameObject objectToRemove)
    {
        if (stack.Contains(objectToRemove))
        {
            int index = stack.IndexOf(objectToRemove);

            for(; index < count; count--)
            {
                stack[index].GetComponent<Rigidbody>().useGravity = true;
                stack.RemoveAt(index);
            }

            if(count == 0)
            {
                StopCoroutine(followPlayerCoroutine);
            }
        }
    }

    public List<GameObject> GetStack()
    {
        return stack;
    }
    public int GetCount()
    {
        return count;
    }

    //For little numbers (like 20-30) this approach should be fine; looping is alright
    private IEnumerator FollowPlayer()
    {
        while(true)
        {
            for(int index = 0; index < count; index++)
            {
                Vector3 followerPosition = stack[index].transform.position;
                Vector3 playerCharacterPosition = playerCharacterTransform.position;
                float xDistance = playerCharacterPosition.x - followerPosition.x;

                //refactor and find better calculations
                float maxDistance = maxDistanceMultiplier * (index + 1);
                float travelSpeed = xDistance * followSpeedMultiplier / (index + 1);

                if(Mathf.Abs(xDistance) <= maxDistance)
                {
                    followerPosition.z = playerCharacterPosition.z;
                    stack[index].transform.position = followerPosition;
                    Rigidbody followerRigidbody = stack[index].GetComponent<Rigidbody>();
                    followerRigidbody.velocity = travelSpeed * transform.right;
                }
                else
                {
                    //Debug.Log(stack[index].name + " is out of range");
                    RemoveFromStack(stack[index]);
                }
            }
            //Debug.Log(followPlayerCoroutine + ": followPlayerCoroutine is working!");
            yield return null;
        }
    }
}
