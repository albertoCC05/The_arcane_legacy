using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiGameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI potionsText;
    [SerializeField] private Slider lifeSlider;



    private void Start()
    {
        updatePotionText(0);
        
    }
    public void LifeSliderUpdate(float life)
    {
        lifeSlider.value = life;
    }
    public void updatePotionText(int numberOfPotions)
    {
        potionsText.text = $"X {numberOfPotions}";
    }
}
