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




    private void Start()
    {
        updatePotionText(0);
        HideGameOverPanel();
        
        
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
}
