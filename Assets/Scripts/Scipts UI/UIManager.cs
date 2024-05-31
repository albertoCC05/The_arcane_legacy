using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager: MonoBehaviour
{

    //This script is for the UI of the main menu scene

    //Panels Reference

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject creditPanel;
    
    //Buttons and UI interactable elements reference

    [SerializeField] private Button playButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button creditButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Toggle muteToggle;

    [SerializeField] private AudioSource musicAudioSource;

    //Scripts Reference

    private GameManager gameManagerScript;
    private DataPersistance dataP;



    private void Start()
    {

        //Scripts set Reference

        gameManagerScript = FindObjectOfType<GameManager>();
        dataP = FindObjectOfType<DataPersistance>();


       //Hide panels at the start of the scene

        HideOptionsPanel();
        HideCreditsPanel();

    }
    private void Update()
    {
        // if you press escape you hide the options panel

        if (Input.GetKeyDown("escape"))
        {
            HideOptionsPanel();
            ShowMainMenuPanel();
            
        }
    }

    // Show and hide panels functions

    public void ShowMainMenuPanel() {
        mainMenuPanel.SetActive(true);
    }

    public void HideMainMenuPanel()
    {
        mainMenuPanel.SetActive(false);
    }
    public void ShowOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }
    public void HideOptionsPanel()
    {
        optionsPanel.SetActive(false);
    }
    public void ShowCreditsPanel()
    {
        creditPanel.SetActive(true);
    }
    public void HideCreditsPanel()
    {
        creditPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    // go to level scene

    public void PlayTheGame()
    {
        SceneManager.LoadScene(1);
    }

    //exit of the game

    public void ExitGame()
    {
        Application.Quit();
    }

    //Set music slider volume function and mute function


    public void MuteMusic(bool musicMuted)
    {
        musicAudioSource.mute = musicMuted;
       
    }


    public void SetSliderValue()
    {
        musicAudioSource.volume = musicSlider.value;
    }

  

}
