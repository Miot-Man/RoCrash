using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    
    public string upgradeType;

    void Start()
    {


    }

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
            }
        }
        Destroy(gameObject);
    }


}
