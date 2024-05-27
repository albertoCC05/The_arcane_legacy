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


    private void Start()
    {
        updatePotionText(0);
        HideGameOverPanel();
        ContinuePausePanel();
        HideControlPausePanel();

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
    }

    public void ControlPausePanel()
    {
        controlsPanel.SetActive(true);

    }

    public void HideControlPausePanel()
    {
        controlsPanel.SetActive(false);
    }


}
