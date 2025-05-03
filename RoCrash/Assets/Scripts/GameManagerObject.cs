using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class GameManagerObject : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI scorecard;

    public GameObject scorebg;
    public GameObject timerbg;
    public EnemySpawn spawner;


    // Start is called before the first frame update
    void Start()
    {
        scorecard.enabled = false;
        GameManager.scorecard = scorecard;
        scorebg.SetActive(false);
        GameManager.scorebg = scorebg;
        spawner = GameManager.spawner.GetComponent<EnemySpawn>();
        


    }
    
    public IEnumerator EndGame()
    {
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        timerText.enabled = false;
        timerbg.SetActive(false);
        //scorecard.text = "Game Over\nEnemies Killed: " + GameManager.score + "\nBosses Killed: " + GameManager.bossesKilled;
        scorecard.enabled = true;
        scorebg.SetActive(true);
        scorecard.text = "qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm";
        yield return wait;
        scorecard.text = "qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm";
        yield return wait;
        scorecard.text = "qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm";
        yield return wait;
        scorecard.text = "qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm";
        yield return wait;
        scorecard.text = "qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm";
        //Time.timeScale = 0f;
        Application.Quit();
        
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
            StartCoroutine(EndGame());
        }

        if (GameManager.timeElapsed > (60 * GameManager.difficulty))
        {
            GameManager.difficulty++;
        }


    
    
    }


    void SpawnBoss()
    {
        spawner.spawn(GameManager.boss);
    }
}
