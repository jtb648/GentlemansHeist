using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    EntitySound sound;

    [SerializeField]
    Transform player;

    //[SerializeField]
    float agroRange;

    //[SerializeField]
    //float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        //sound = GameObject.FindGameObjectWithTag("Player").GetComponent<EntitySound>();
        //double realRange = sound.GetCurrentRadius()*0.5;

        //agroRange = player.GetComponentInChildren<CircleCollider2D>().radius * player.GetChild(0).localScale.x / 2;
        //print("distToPlayer:" + distToPlayer + "agro"+ agroRange);
        print(distToPlayer);


        if(player.GetComponentInChildren<CircleCollider2D>().IsTouching(this.gameObject.GetComponent<CircleCollider2D>()))
        {
            PlayerFound();
        }
        else
        {
            PlayerNotFound();
        }
        
    }

    void PlayerFound()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    void PlayerNotFound()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }
}
