using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistance : MonoBehaviour
{
    //Save Variables

    private const string ENEMIESDEFEATED = "Enemies";
   
    //Scripts references

    private GameManager gameManager;
    private UIManager uiManager;

    private void Start()
    {
        //Set scripts references

        gameManager = FindObjectOfType<GameManager>();
        uiManager = FindObjectOfType<UIManager>();
    }
    private void Update()
    {
        //Save and load the data, if you pres "G" in the keyboard you save, and if you pres "H" you load de Data

        if ( Input.GetKeyDown(KeyCode.G))
        {
            SaveEnemiesDefeated();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            LoadEnemiesDefeated();
        }
    }

    //Save Function, with this function we save with PlayerPrefs the number of enemies defeated

    public void SaveEnemiesDefeated()
    {
        

        int enemiesToDefeat = gameManager.GetEnemiesDefeated();
        PlayerPrefs.SetInt(ENEMIESDEFEATED, enemiesToDefeat);

    }

    //Load Function, with this function we load the number of enemies defeated

    public void LoadEnemiesDefeated()
    {
        if (PlayerPrefs.HasKey(ENEMIESDEFEATED))
        {
            int enemiesToDefeat = PlayerPrefs.GetInt(ENEMIESDEFEATED);
            gameManager.SetEnemiesDefeated(enemiesToDefeat);
        }
    }
}
