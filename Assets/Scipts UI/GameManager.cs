using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private UIManager uiManager;

    [SerializeField] private AudioSource musicAudioSource;


    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        uiManager.HideOptionsPanel();
        uiManager.HideCreditsPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            uiManager.HideOptionsPanel();
            uiManager.ShowMainMenuPanel();
        }
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

}
