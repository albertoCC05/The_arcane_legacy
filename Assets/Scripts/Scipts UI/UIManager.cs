using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager: MonoBehaviour
{

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject creditPanel;

    [SerializeField] private Button playButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button creditButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backButton;

    [SerializeField] private Slider musicSlider;

    [SerializeField] private Toggle muteToggle;

    private GameManager gameManagerScript;

    private void Start()
    {

        gameManagerScript = FindObjectOfType<GameManager>();

        musicSlider.onValueChanged.AddListener(gameManagerScript.SetMusicVolume);

        HideOptionsPanel();
        HideCreditsPanel();

        playButton.onClick.AddListener(() => { gameManagerScript.PlayTheGame(); } );
        optionButton.onClick.AddListener(() => { gameManagerScript.OptionsMenu(); } );
        backButton.onClick.AddListener(() => { gameManagerScript.MainMenu(); } );
        exitButton.onClick.AddListener(() => { gameManagerScript.ExitGame(); } );
        creditButton.onClick.AddListener(() => { gameManagerScript.CreditPanel(); });

    }
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            HideOptionsPanel();
            ShowMainMenuPanel();
        }
    }

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
    /*public void ShowMainMenuPanel()
    {
        mainMenuPanel.SetActive(true);
    }
    public void ShowMainMenuPanel()
    {
        mainMenuPanel.SetActive(true);
    }
   */
    public void ShowCreditsPanel()
    {
        creditPanel.SetActive(true);
    }
    public void HideCreditsPanel()
    {
        creditPanel.SetActive(false);
    }

    public void SetSliderValue(float value)
    {
        musicSlider.value = value;
    }

}
