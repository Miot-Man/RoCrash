using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float time = 5f;
    private float timer = 0f;
    public GameObject op;
    public float spawnrange = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            timer = 0f;
            Instantiate(op, new Vector3(Random.Range(-spawnrange,spawnrange) + GameManager.playerpos.x, Random.Range(-spawnrange, spawnrange) + GameManager.playerpos.y, 0), Quaternion.identity);
        }
    }
}
