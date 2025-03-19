using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    public float health = 10f;
    public healthbar healthbar;
    
    void Start()
    {
        GameManager.player = gameObject;
        healthbar.setmaxhealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IDamageable.damage(float damage)
    {
        health -= damage;
        healthbar.sethealth(health);
        Debug.Log("Player Took Damage");
        if (health <= 0)
        {
            GameManager.numenemies--;
            Destroy(gameObject);
        }
    }
}
