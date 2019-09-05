using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip beep;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = beep;
    }

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
        //Debug.Log("PIP Left");

        audioSource.Play();
    }

    void ButtonInput_OnRight()
    {
        //Debug.Log("PIP Right");

        audioSource.Play();
    }

}
