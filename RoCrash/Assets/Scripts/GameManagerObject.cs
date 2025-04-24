using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerObject : MonoBehaviour
{

    public float timeLeft = GameManager.timeLeft;
    public float timeElapsed = GameManager.timeElapsed;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeElapsed += Time.deltaTime;
        timerText.text = "Time Left: " + Mathf.Round(timeLeft).ToString();
        if (timeLeft <= 0)
        {
            GameManager.endGame();
        }

    
    
    }


    void SpawnBoss()
    {
        GameManager.spawner.GetComponent<EnemySpawn>().spawn(GameManager.boss);
    }
}
