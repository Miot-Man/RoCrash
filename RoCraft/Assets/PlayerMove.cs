using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Initialise variables
    public float movespeed = 5f;
    public Rigidbody2D rb;
    Vector2 Movement;
    private void Update()
    {
        //Input
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + Movement * movespeed * Time.fixedDeltaTime);

    }
}
