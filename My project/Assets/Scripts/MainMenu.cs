using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Hier wordt de level scene geladen
    public string lvToLoad;
    
    public int dfltLives;

    private void Start()
    {
        PlayerPrefs.SetInt("CurrentLives", dfltLives);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(lvToLoad);
    }
    
    // hier wordt de game afgelosten
    public void QuitGame()
    {
        Application.Quit();
    }
}
