using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;
    private Rigidbody2D rb;
    public void setup(float speed, float damage)
    {
        this.damage = damage;
        rb = GetComponent<Rigidbody2D>();
        //find mouse position
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mousepos - GameManager.playerpos;
        //add velocity to bullet
        rb.velocity = (dir.normalized * speed) + GameManager.playervelo;
        //destroy bullet after 5 seconds
        Invoke("death", 5f);
    }
    void death()
    {
        Destroy(gameObject);

    }
}
