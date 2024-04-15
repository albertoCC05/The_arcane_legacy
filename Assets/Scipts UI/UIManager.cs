using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager: MonoBehaviour
{

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;

    [SerializeField] private Button playButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button backButton;

    [SerializeField] private Slider musicSlider;

    [SerializeField] private Toggle muteToggle;

    private GameManager gameManagerScript;

    private void Start()
    {

        gameManagerScript = FindObjectOfType<GameManager>();

        optionButton.onClick.AddListener(() => { gameManagerScript.OptionsMenu(); } );
        backButton.onClick.AddListener(() => { gameManagerScript.MainMenu(); } );
        exitButton.onClick.AddListener(() => { gameManagerScript.ExitGame(); } );

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

}
