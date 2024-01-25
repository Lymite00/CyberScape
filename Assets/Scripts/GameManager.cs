using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStarted = false;
    public bool canSpawn = false;
    public GameObject player;
    public Transform spawnPoint;

    public float timer;
    

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameStarted = false;
        canSpawn=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            timer -= Time.deltaTime;
            if (timer<=0)
            {
                RestartGame();
            }
        }
    }

    public void RestartGame()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
        timer = 60f;
    }
}
