using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGuard : MonoBehaviour
{
    public int rangeFrames = 360;
    GameObject guard;

    private void Start()
    {
        guard = GameObject.FindGameObjectsWithTag("Guard")[0];
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), guard.GetComponentInChildren<Collider2D>());
    }

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
        /*        if (collision.gameObject.CompareTag("ENTER TAG HERE"))
                {
                    // Behavior on that specific tag
                    // ex: collision.gameObject.GetComponent<HealthBar>().setHealth(0);
                }*/
        if (collision.gameObject.CompareTag("Player")) //When player gets shot
        {
            //add player health reduction or whatever should go here
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Guard"))
        {
            Debug.LogWarning("Guard is suicidal, stop that");
        }
        else if (collision.collider)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 5f);
    }
        
}
