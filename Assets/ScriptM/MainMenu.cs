using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Player has Quit The Game");
        PlayerPrefs.DeleteAll();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("level", 1);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
    }
}
