using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
public float Speed;
public float JumpForce;
    void Start()
    {
        // Corregido: 'GetComponent' (con 'n'), paréntesis angular '>' y paréntesis final '()'
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
    }
    private void FixedUpdate()
    {
       
        Rigidbody2D.linearVelocity = new Vector2(Horizontal , Rigidbody2D.linearVelocity.y);
    }
}