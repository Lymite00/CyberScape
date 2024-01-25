using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance;
    
    public GameObject gamePanel;
    public GameObject pausePanel;
    public GameObject finishPanel;
    public GameObject infoPanel;

    public Slider progressSlider;
    
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        progressSlider.value = 0;
        progressSlider.interactable = false;
        progressSlider.wholeNumbers = false;
        gamePanel.SetActive(true);
        pausePanel.SetActive(false);
        finishPanel.SetActive(false);
        infoPanel.SetActive(false);
    }

    private IEnumerator GameFinished()
    {
        yield return new WaitForSeconds(1f);
        PlayerController.instance.gameObject.SetActive(false);
        PlayerController.instance.Particle();
        yield return new WaitForSeconds(1f);
        finishPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void IncreaseSlider()
    {
        progressSlider.value += 1;
    }
    public void ButtonClick()
    {
        SoundController.instance.aSource.PlayOneShot(SoundController.instance.buttonCLick);
    }
    public void OpenInfo()
    {
        infoPanel.SetActive(true);
        gamePanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void CloseInfo()
    {
        infoPanel.SetActive(false);
        gamePanel.SetActive(true);
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        gamePanel.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void FinishGame()
    {
        gamePanel.SetActive(false);
        StartCoroutine(GameFinished());
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex+1;
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void ResumeGame()
    {
        gamePanel.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
