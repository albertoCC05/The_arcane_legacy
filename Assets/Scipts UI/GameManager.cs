using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private UIManager uiManager;


    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        uiManager.HideOptionsPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            uiManager.HideOptionsPanel();
            uiManager.ShowMainMenuPanel();
        }
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

}
