using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameManager
{
    //Global Variables
    public static Vector2 playerpos;
    public static Vector2 playervelo;
    public static float weapondamage;
    public static int numenemies;

    public static GameObject player;

    public static GameObject spawner;

    public static GameObject boss;

    public static TMPro.TextMeshProUGUI scorecard;
    public static GameObject scorebg;
    
    
    public static void endGame()
    {
        scorecard.text = "Game Over\nEnemies Killed: " + score + "\nBosses Killed: " + bossesKilled;
        scorecard.enabled = true;
        scorebg.SetActive(true);
        Time.timeScale = 0f;
        Application.Quit();
        
    }



    public static float damagemult = 1f;
    public static float healthmult = 1f;

    public static float timeLeft = 120f;
    public static float timeElapsed = 0f;
    public static int difficulty = 1;
    public static float timeIncrease = 30f;

    public static int enemiesKilled = 0;
    public static int enemiesSpawned = 0;
    public static int score = 0;

    public static int bossesKilled = 0;

    public static bool bossSpawned = false;

  
}
