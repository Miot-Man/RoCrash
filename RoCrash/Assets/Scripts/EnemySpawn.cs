using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float time = 5f;
    private float timer = 0f;
    public GameObject enemy;
    public GameObject boss;
    public float spawnrange = 5f;
    public float x = 5f;
    void Start()
    {
        GameManager.numenemies = 0;
        GameManager.spawner = gameObject;
        GameManager.boss = boss;
    }

    public void spawn(GameObject enemyType){
                Vector3 temp = new Vector3(Random.Range(-spawnrange,spawnrange) + GameManager.playerpos.x, Random.Range(-spawnrange, spawnrange) + GameManager.playerpos.y, 0);
                while (-x <= temp.x && temp.x <= x || -x <= temp.y && temp.y <= x){
                    temp = new Vector3(Random.Range(-spawnrange,spawnrange) + GameManager.playerpos.x, Random.Range(-spawnrange, spawnrange) + GameManager.playerpos.y, 0);
                }
                Instantiate(enemyType, temp, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            timer = 0f;
            if (GameManager.numenemies <= 9){
                GameManager.numenemies++;
                spawn(enemy);
            }
        }
    }
}
