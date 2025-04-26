using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerObject : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI scorecard;

    public GameObject scorebg;


    // Start is called before the first frame update
    void Start()
    {
        scorecard.enabled = false;
        GameManager.scorecard = scorecard;
        scorebg.SetActive(false);
        GameManager.scorebg = scorebg;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.enemiesKilled >= (5 + 5*GameManager.bossesKilled) && !GameManager.bossSpawned)
        {
            GameManager.bossSpawned = true;
            SpawnBoss();
        }


        GameManager.timeLeft -= Time.deltaTime;
        GameManager.timeElapsed += Time.deltaTime;
        timerText.text = "Time Left: " + Mathf.Round(GameManager.timeLeft).ToString() + "\nDifficulty: " + GameManager.difficulty.ToString();
        if (GameManager.timeLeft <= 0)
        {
            GameManager.endGame();
        }

        if (GameManager.timeElapsed > (60 * GameManager.difficulty))
        {
            GameManager.difficulty++;
        }


    
    
    }


    void SpawnBoss()
    {
        GameManager.spawner.GetComponent<EnemySpawn>().spawn(GameManager.boss);
    }
}
