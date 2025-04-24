using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    
    public static void endGame()
    {
        Time.timeScale = 0f;
        Application.Quit();
    }



    public static float damagemult = 1f;
    public static float healthmult = 1f;

    public static float timeLeft = 60f;
    public static float timeElapsed = 0f;
    public static float timeIncrease = 30f;

    public static int enemiesKilled = 0;
    public static int enemiesSpawned = 0;

    public static int bossesKilled = 0;

  
}
