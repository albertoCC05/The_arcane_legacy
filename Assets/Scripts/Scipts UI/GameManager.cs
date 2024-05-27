using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private UIManager uiManager;
    private UiGameManager uiGame;

    [SerializeField] private AudioSource musicAudioSource;

    private bool isGameOver = false;


    void Start()
    {
        Time.timeScale = 1f;

        isGameOver = false;

        uiGame = FindObjectOfType<UiGameManager>();
        uiManager = FindObjectOfType<UIManager>();

        

       
    }


    public void PlayTheGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OptionsMenu()
    {
        uiManager.ShowOptionsPanel();
    }

    public void MainMenu()
    {
        uiManager.HideOptionsPanel();
        uiManager.ShowMainMenuPanel();

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CreditPanel()
    {
        uiManager.HideMainMenuPanel();
        uiManager.ShowCreditsPanel();
    }

    public void SetMusicVolume(float volume)
    {
        musicAudioSource.volume = volume;
    }

    public void MuteMusic(bool musicMuted)
    {
        musicAudioSource.mute = musicMuted;
        uiManager.SetSliderValue(0);
    }

    public void SetGameOver()
    {
        isGameOver = true;
        uiGame.ShowGameOverPanel();
        Time.timeScale = 0;

       
    }

}
