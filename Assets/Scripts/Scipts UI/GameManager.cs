using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Scripts references

    private UIManager uiManager;
    private UiGameManager uiGame;
    private DataPersistance dataP;

    //Audio source reference

    [SerializeField] public AudioSource musicAudioSource;

    //game variables

    private bool isGameOver = false;
    private int enemiesToDefeat = 10;

    //boss fog reference, used it for desactivate it when you defeat all the enemies that you have to defeat to go to the boos

    [SerializeField] private GameObject bossFog;

    void Start()
    {

        //Set scripts reference

        uiGame = FindObjectOfType<UiGameManager>();
        uiManager = FindObjectOfType<UIManager>();
        dataP = FindObjectOfType<DataPersistance>();


        // Set the variable is game over to false at the beggining of the scene

        isGameOver = false;

        //we update the text of number of enemies at the start of the scene

        uiGame.UpdateEnemiesText(enemiesToDefeat);

    }

    // Game over function, it is called when the player dies

    public void SetGameOver()
    {
        isGameOver = true;
        uiGame.ShowGameOverPanel();
        Time.timeScale = 0;
    }

    // Number of enemies defeated, the initial number is 10 and when you defeat 1 when substract 1 to the enemies counter
    // also when the counter is modified we update the enemies left text of the ui
    // when the number of enemies equals to 0 the boss fog is desactivated and you can go to there to defeat him

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

    //This function is to load the number of enemies defeated before you had save this information

    public void SetEnemiesDefeated( int enemiesDefeated)
    {
        enemiesToDefeat = enemiesDefeated;
        uiGame.UpdateEnemiesText(enemiesToDefeat);

        // also if you save the number of enemies defeated when this number equals to 0 you unlock the boss zone

        if (enemiesToDefeat <= 0)
        {
            bossFog.SetActive(false);
        }
    }

    //This function is to get the number of enemies defeated to save it whith data persistance

    public int GetEnemiesDefeated()
    {
        return enemiesToDefeat;
    }
}
