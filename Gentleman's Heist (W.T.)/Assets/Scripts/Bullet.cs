using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int rangeFrames = 360;

    void FixedUpdate()
    {
        if (rangeFrames > 0)
        {
            rangeFrames -= 1;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.LogWarning("Bullet hit player, which isn't good!");
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // Behavior on that specific tag
            // ex: collision.gameObject.SetActive(false);
            // ex: collision.gameObject.GetComponent<HealthBar>().setHealth(0);
            Destroy(gameObject, 0.25f);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
        
}
