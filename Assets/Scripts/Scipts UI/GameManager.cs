using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private UIManager uiManager;
    private UiGameManager uiGame;

    [SerializeField] public AudioSource musicAudioSource;

    private bool isGameOver = false;
    private int enemiesToDefeat;
    [SerializeField] private GameObject bossFog;
    private DataPersistance dataP;




    void Start()
    {
        dataP = FindObjectOfType<DataPersistance>();

        Time.timeScale = 1f;

        isGameOver = false;

        uiGame = FindObjectOfType<UiGameManager>();
        uiManager = FindObjectOfType<UIManager>();

        enemiesToDefeat = 2;
        uiGame.UpdateEnemiesText(enemiesToDefeat);

        


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
    public void EnemiesDefeated()
    {
        enemiesToDefeat--;
        if (enemiesToDefeat <= 0)
        {
            enemiesToDefeat = 0;
            bossFog.SetActive(false);
        }

        uiGame.UpdateEnemiesText(enemiesToDefeat);

    }
    public void SetEnemiesDefeated( int enemiesDefeated)
    {
        enemiesToDefeat = enemiesDefeated;
        uiGame.UpdateEnemiesText(enemiesToDefeat);

        if (enemiesToDefeat <= 0)
        {
            bossFog.SetActive(false);
        }
    }
    public int GetEnemiesDefeated()
    {
        return enemiesToDefeat;
    }
}
