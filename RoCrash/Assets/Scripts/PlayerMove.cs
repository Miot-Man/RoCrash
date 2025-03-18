using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Initialise variables
    public float movespeed = 5f;
    public Rigidbody2D rb;
    private Vector2 pos;
    Vector2 Movement;
    private void Update()
    {
        //Input
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
        //update global position tracker
        GameManager.playerpos = transform.position;
     
    }

    void FixedUpdate()
    {
        //Movement
        pos = rb.position + Movement.normalized * movespeed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
        //update global player velocity
        GameManager.playervelo = Movement.normalized * movespeed;

    }
}
