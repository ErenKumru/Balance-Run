using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public float input;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            input = Input.GetTouch(0).deltaPosition.x;
        }
        else input = 0f;
    }
}
