using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;
    private Rigidbody2D rb;
    public LayerMask whatDestroysBullet;
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
     void OnTriggerEnter2D(Collider2D col)
        {
            if ((whatDestroysBullet.value & (1 << col.gameObject.layer)) > 0)
            {
                col.GetComponent<IDamageable>().damage(this.damage);
                death();
            }
        }
    void death()
    {
        Destroy(gameObject);

    }
}
