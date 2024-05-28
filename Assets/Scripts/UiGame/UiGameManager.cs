using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiGameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI potionsText;
    [SerializeField] private Slider lifeSlider;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject startControlsPanel;
        


    private void Start()
    {
        updatePotionText(0);
        HideGameOverPanel();
        ContinuePausePanel();
        HideControlPausePanel();
        ShowControls();

        Time.timeScale = 0;

    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            ShowPausePanel();
        }
    }


    public void LifeSliderUpdate(float life)
    {
        lifeSlider.value = life;
    }
    public void updatePotionText(int numberOfPotions)
    {
        potionsText.text = $"X {numberOfPotions}";
    }
    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

   
    public void RestartPausePanel()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinuePausePanel ()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ControlPausePanel()
    {
        controlsPanel.SetActive(true);

    }

    public void HideControlPausePanel()
    {
        controlsPanel.SetActive(false);
    }
    public void ShowControls()
    {
        startControlsPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public void HideControls()
    {
        startControlsPanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }


}
