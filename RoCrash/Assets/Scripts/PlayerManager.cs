using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    public float health = 10f;
    private float maxhealth = 10f;
    private float basehealth;
    public healthbar healthbar;
    
    void Start()
    {
        GameManager.player = gameObject;
        healthbar.setmaxhealth(health);
        basehealth = maxhealth;
    }

    // Update is called once per frame
    public void IncreaseHealth()
    {
        maxhealth = basehealth * GameManager.healthmult;
        healthbar.setmaxhealth(maxhealth);
    }

    public void heal()
    {
        health += maxhealth * 0.2f;
        if (health > maxhealth)
        {
            health = maxhealth;
        }
        healthbar.sethealth(health);
    }
    void IDamageable.damage(float damage)
    {
        health -= damage;
        healthbar.sethealth(health);
        Debug.Log("Player Took Damage");
        if (health <= 0)
        {
            GameManager.endGame();
        }
    }
}
