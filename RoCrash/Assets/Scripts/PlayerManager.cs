using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    public float health = 10f;
    
    void Start()
    {
        GameManager.player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IDamageable.damage(float damage)
    {
        health -= damage;
        Debug.Log("Player Took Damage");
        if (health <= 0)
        {
            GameManager.numenemies--;
            Destroy(gameObject);
        }
    }
}
