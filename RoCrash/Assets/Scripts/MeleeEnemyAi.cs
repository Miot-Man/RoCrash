using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeleeEnemyAi : MonoBehaviour, IDamageable
{
    public float health = 3f;
    public float movespeed = 3f;
    public float damage = 1f;
    public LayerMask whatDamagesPlayer;
    public GameObject[] upgrades = new GameObject[5];
    Rigidbody2D rb;
    Transform target;
    Vector2 movedir;

    bool bounce;
    float bouncetimer = 0f;

    public String enemyType;

    bool canattack = true;
    float timer = 0f;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        target = GameManager.player.transform;
        bounce = false;
    }
    void OnTriggerEnter2D(Collider2D col)
        {
            if (((whatDamagesPlayer.value & (1 << col.gameObject.layer)) > 0) && canattack)
            {
                canattack = false;
                timer = 0f;
                col.GetComponent<IDamageable>().damage(this.damage);
                bounce = true;
                bouncetimer = 0f;
                rb.AddForce(-movedir * 10, ForceMode2D.Impulse);
            }
        }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!canattack && (timer >= 0.5f)){
            canattack = true;
        }
        if (target){
            Vector2 dir = (target.position - transform.position).normalized;
            movedir = dir;
        }


    }

    void FixedUpdate()
    {
        if (target){
            if (bounce)
            {
                bouncetimer += Time.deltaTime;
                if (bouncetimer >= 0.5f)
                {
                    bounce = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(movedir.x, movedir.y) * movespeed;
            }
        }
    }
    void IDamageable.damage(float damage)
    {


        health -= damage;
        UnityEngine.Debug.Log("Took Damage");
        if (health <= 0)
        {
            switch (enemyType){
                case "Enemy":
                 if (Random.Range(0, 100) < 90)
                    {
                    Instantiate(upgrades[Random.Range(0,upgrades.Length)], transform.position, Quaternion.identity);
                    }
            
                GameManager.numenemies--;
                GameManager.enemiesKilled++;
                UnityEngine.Debug.Log("Enemies Killed: " + GameManager.enemiesKilled);

                if (GameManager.enemiesKilled == Math.Max(5, 5*GameManager.bossesKilled))
                {
                    
                }
                Destroy(gameObject);
                break;
                case "Boss":
                    GameManager.timeLeft += GameManager.timeIncrease;
                    GameManager.timeIncrease *= 0.9f;
                    GameManager.bossesKilled++;
                    Destroy(gameObject);
                    GameManager.bossSpawned = false;
                    GameManager.enemiesKilled = 0;
                    break;
            }
           
        }
    }
}
