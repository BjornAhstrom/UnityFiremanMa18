﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{

    public bool left;

    private void OnMouseDown()
    {
        if (left)
        {
            Debug.Log("Touch left");
        }
        else
        {
            Debug.Log("Touch right");
        }

    }

}