using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    //Panels
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject characterSelectPanel;

    //Buttons
    [SerializeField] private Button playButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button socialEmre;
    [SerializeField] private Button socialUmeyr;

    public Button[] backButtons;

   
    private void Awake()
    {
        instance = this;
        characterSelectPanel.SetActive(false);
        gamePanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    private void Start()
    {
        musicButton.onClick.AddListener(MusicController.instance.ToggleMusic);
    }

    public void ButtonClick()
    {
        SoundController.instance.aSource.PlayOneShot(SoundController.instance.buttonCLick);
    }
    
    public void StartGamePanel()
    {
        menuPanel.SetActive(false);
        characterSelectPanel.SetActive(true);
    }
    public void StartGamePanelBack()
    {
        menuPanel.SetActive(true);
        characterSelectPanel.SetActive(false);
    }

    public void StartLevelSelect()
    {
        characterSelectPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void StartLevelSelectBack()
    {
        characterSelectPanel.SetActive(true);
        gamePanel.SetActive(false);
    }
    public void StartCreditPanel()
    {
        menuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    public void StartCreditPanelBack()
    {
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    public void StartSettingsPanel()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void StartSettingsPanelBack()
    {
        menuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }
    public void Level3()
    {
        SceneManager.LoadScene(3);
    }
    public void Level4()
    {
        SceneManager.LoadScene(4);
    }

    public void Emre()
    {
        Application.OpenURL("https://emrecayl.itch.io/");
    }

    public void Umeyr()
    {
        Application.OpenURL("https://linktr.ee/lymite");
    }
}
