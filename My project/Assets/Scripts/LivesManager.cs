using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public int livesCounter;

    public Text livesText;

    private GameManager TheGM;
    
    // Start is called before the first frame update
    void Start()
    {
        livesCounter = PlayerPrefs.GetInt("CurrentLives");
        
        TheGM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "x " + livesCounter;
        if (livesCounter <1)
        {
            TheGM.GameOver();
        }
    }

    public void TakeLife()
    {
        livesCounter--;
        PlayerPrefs.SetInt("CurrentLives", livesCounter);
        
    }
    
    public void AddLife()
    {
        livesCounter++;
        PlayerPrefs.SetInt("CurrentLives", livesCounter);
    }
}
