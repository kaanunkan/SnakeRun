using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    private static Text txtHighScore, txtLastScore;
    
    
    private void Start()
    {
        int lastScore = PlayerPrefs.GetInt("Score", 0);
        
        if (lastScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", lastScore);
        }
        
        txtHighScore = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<Text>();
        txtHighScore.text = "High Score : " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        
        txtLastScore = GameObject.FindGameObjectWithTag("LastScore").GetComponent<Text>();
        txtLastScore.text = "Your Last Score : " + lastScore.ToString();
    }

    public void StartGameSr()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level01");
    }

    public void QuitGameSr()
    {
        Application.Quit();
    }
}
