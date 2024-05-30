using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistance : MonoBehaviour
{
    private const string ENEMIESDEFEATED = "Enemies";
   

    private GameManager gameManager;
    private UIManager uiManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        uiManager = FindObjectOfType<UIManager>();
    }
    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.G))
        {
            SaveEnemiesDefeated();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            LoadEnemiesDefeated();
        }
    }
    public void SaveEnemiesDefeated()
    {
        

        int enemiesToDefeat = gameManager.GetEnemiesDefeated();
        PlayerPrefs.SetInt(ENEMIESDEFEATED, enemiesToDefeat);

    }
    public void LoadEnemiesDefeated()
    {
        if (PlayerPrefs.HasKey(ENEMIESDEFEATED))
        {
            int enemiesToDefeat = PlayerPrefs.GetInt(ENEMIESDEFEATED);
            gameManager.SetEnemiesDefeated(enemiesToDefeat);
        }
    }
}
