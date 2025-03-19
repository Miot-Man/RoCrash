using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAi : MonoBehaviour, IDamageable
{
    public float health = 3f;
    public float movespeed = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    void IDamageable.damage(float damage)
    {
        health -= damage;
        Debug.Log("Took Damage");
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
