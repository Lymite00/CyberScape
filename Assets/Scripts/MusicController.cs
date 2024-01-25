using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    
    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip music;
    
    public bool isMusicPlaying = true;
    
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
    void Update()
    {
        
    }
    public void ToggleMusic()
    {
        if (isMusicPlaying)
        {
            aSource.Pause();
        }
        else
        {
            aSource.UnPause();
        }

        isMusicPlaying = !isMusicPlaying;
    }
}
