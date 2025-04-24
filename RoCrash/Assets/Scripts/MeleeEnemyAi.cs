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
    public LayerMask enemybouncer;


    public GameObject[] upgrades = new GameObject[5];
    Rigidbody2D rb;
    [SerializeField] Transform target;
    Vector2 movedir;


    [SerializeField] bool bounce = false;
    float bounceCd = 0f;


    public String enemyType;

    bool canattack = true;
    float timer = 0f;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        target = GameManager.player.transform;
    }


    void Bounce(Vector2 dir, float f )
    {

        bounce = true;
        rb.AddForce((-rb.velocity) + -dir * f, ForceMode2D.Impulse);

    }


    void OnTriggerStay2D(Collider2D col)
        {
            if (((whatDamagesPlayer.value & (1 << col.gameObject.layer)) > 0) && canattack)
            {
                canattack = false;
                timer = 0f;
                col.GetComponent<IDamageable>().damage(this.damage);

                Bounce((col.transform.position - transform.position).normalized, 20f);

            }
            if (((enemybouncer.value & (1 << col.gameObject.layer)) > 0) && !bounce)
            {
                
                Bounce((col.transform.position - transform.position).normalized, 5f);
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
                bounceCd += Time.fixedDeltaTime;
                if (bounceCd >= 0.5f)
                {
                    bounce = false;
                    bounceCd = 0f;
                }}
                else{
                //rb.velocity = new Vector2(movedir.x, movedir.y) * movespeed;
                if (rb.velocity.magnitude < movespeed)
                {
                    rb.AddForce(movedir * movespeed, ForceMode2D.Impulse);
                }       
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
                GameManager.score += 1;
                UnityEngine.Debug.Log("Enemies Killed: " + GameManager.enemiesKilled);
                Destroy(gameObject);
                break;
                case "Boss":
                    GameManager.timeLeft += GameManager.timeIncrease;
                    GameManager.timeIncrease *= 0.9f;
                    GameManager.bossesKilled++;
                    GameManager.bossSpawned = false;
                    GameManager.enemiesKilled = 0;
                    Destroy(gameObject);
                    
                    break;
            }
           
        }
    }
}
