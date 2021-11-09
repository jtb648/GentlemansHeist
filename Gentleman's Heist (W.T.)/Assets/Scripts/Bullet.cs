using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int rangeFrames = 360;

    void Update()
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
        if (collision.gameObject.CompareTag("ENTER TAG HERE"))
        {
            // Behavior on that specific tag
            // ex: collision.gameObject.GetComponent<HealthBar>().setHealth(0);
        }
        Destroy(gameObject,.5f);
    }
        
}
