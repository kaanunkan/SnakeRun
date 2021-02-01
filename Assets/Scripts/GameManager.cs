using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
//    public GameObject mySnake;
    private static int score = 0;
    private static int health = 3;
    public Image[] heart;
    
    private static Text txtScore;    
    
    private void Awake()
    {
//        mySnake = (GameObject) Instantiate(mySnake,transform.position,Quaternion.identity);
//        mySnake.name = "BlueHead";
        txtScore = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        NodeMovement.SetSpeed(5f);
        SnakeHeadController.SetSpeed(5f);
        score = 0;
        health = 3;
    }

    private void Update()
    {
        if (health < 3)
            heart[health].enabled = false;
    }


    public static void SetAddScore(int addScore)
    {
        score += addScore;
        txtScore.text = score.ToString();

        PlayerPrefs.SetInt("Score", score);
        if (score%1000 == 0)
        {
            NodeMovement.SetAddSpeed(1f);
            SnakeHeadController.SetAddSpeed(1f);
        }
    }

    public static void DecreaseHealth()
    {
        health--;
    }

    public static int GetHealth()
    {
        return health;
    }
}
