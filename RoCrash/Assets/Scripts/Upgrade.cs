using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string upgradeType;
    
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("straight upgrading");
            switch (upgradeType){
                case "Damage":
                    GameManager.damagemult *= 1.5f;
                    break;
                case "Health":
                    GameManager.healthmult += 2f;
                    GameManager.player.GetComponent<PlayerManager>().IncreaseHealth();
                    break;
                case "Healthpack":
                    GameManager.player.GetComponent<PlayerManager>().heal();
                    break;
            }
            Destroy(gameObject);
        }
        
    }

}
