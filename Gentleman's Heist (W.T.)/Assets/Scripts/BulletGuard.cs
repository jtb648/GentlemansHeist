using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGuard : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player")) //When player gets shot
        {
            collision.gameObject.GetComponent<EnemyAI>().gotShot();
        }
        if (collision.collider)
        {
            //Destroy(gameObject, 0f);
        }
        Destroy(gameObject,2f);
    }
        
}
