using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    
    public static SoundController instance;
    
    public AudioSource aSource;
    public AudioClip buttonCLick;
    
    public bool isButtonPlaying = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    private void Update()
    {
        if (isButtonPlaying)
        {
            aSource.volume =0f;
        }
        else
        {
            aSource.volume =0.6f;
        }
    }

    public void ToggleSound()
    {
        isButtonPlaying = !isButtonPlaying;
    }
}
