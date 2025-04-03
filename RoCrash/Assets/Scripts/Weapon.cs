using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //weapon & bullet attributes
    public float firerate = 2f;
    public GameObject projectile;
    public float damage = 1f;
    public float projectilespeed = 5f;
    //private variables
    private float firetimer;
    private float firetime = 0f;
    void Start()
    {
        //inverse firerate to allow for correct if statement
        firetime = 1 / firerate;
    }
    void fire()
    {
        //count until firetimer >= firetime
        firetimer += Time.deltaTime;
        if(firetimer >= firetime && Input.GetKey(KeyCode.Mouse0))
        {
            firetimer = 0f;
            //create bullet object and setup with attributes
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().setup(projectilespeed, damage);
            
            
        }

    }
    void Update()
    {
        fire();
        if (Input.GetKeyDown(KeyCode.U))
        {
            UpgradeManager.damageupgrade++;
            Debug.Log("Damage upgraded");
            damage = (float)Math.Pow(1.5, UpgradeManager.damageupgrade);
        }
    }
}
