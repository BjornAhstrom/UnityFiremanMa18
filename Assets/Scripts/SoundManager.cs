using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private void OnEnable()
    {
        ButtonInput.OnLeft += ButtonInput_OnLeft;
        ButtonInput.OnRight += ButtonInput_OnRight;

    }

    private void OnDisable()
    {
        ButtonInput.OnLeft -= ButtonInput_OnLeft;
        ButtonInput.OnRight -= ButtonInput_OnRight;
    }

    void ButtonInput_OnLeft()
    {
        Debug.Log("PIP Left");
    }

    void ButtonInput_OnRight()
    {
        Debug.Log("PIP Right");
    }

}
