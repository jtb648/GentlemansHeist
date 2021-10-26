using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveMovement : MonoBehaviour
{
    public float speed = 3f;

    public Rigidbody2D rb;

    private Vector2 _movement;
    
    
    // Update is called once per frame
    void Update()
    {
        rb.velocity = _movement * speed;
    }

    private void FixedUpdate()
    {
        _movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
}
