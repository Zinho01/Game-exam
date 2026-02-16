using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    
    public PlayerController thePlayer;
    private Vector2 playerStart;

    public GameObject victoryScreen;
    public GameObject gameOverScreen;
    
    public string mainMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        // start positie van de speler
        playerStart = thePlayer.transform.position;
        
        
    }

    public void Victory()
    {
        // winner scherm is actief
        victoryScreen.SetActive(true);
        // player is inactief
        thePlayer.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        // game over scherm is actief
        gameOverScreen.SetActive(true);
        // player is inactief 
        thePlayer.gameObject.SetActive(false);
        
        StartCoroutine("GameReset");
    }
    
    // Na game over wordt je na 3 seconden terug geladen naar de het menu 
    IEnumerator GameReset()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(mainMenu);
    }

    public void Reset()
    {
        // de game over scherm als de winner zelf is inactief
        victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        // player is actief en terug op zijn standaard plek
        thePlayer.gameObject.SetActive(true);
        thePlayer.transform.position = playerStart;
    }
}
