using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardGraphics : MonoBehaviour
{

    
    public Animator animator;
    private float xMove;
    private float yMove;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void rotationStablizer()
    {
        float zed = transform.parent.gameObject.transform.rotation.z;
        transform.rotation = Quaternion.Euler(0, 0, zed);
    }

    void animationChangerDirectionColorTest()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0];
        float distToPlayer = Vector2.Distance(this.transform.parent.position, target.transform.position);
        if (distToPlayer >= 10)
        {
            if (transform.localRotation.eulerAngles.z >= 0 && transform.localRotation.eulerAngles.z <= 90)//down left area
            {
                this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
            if (transform.localRotation.eulerAngles.z > 90 && transform.localRotation.eulerAngles.z <= 180)//up left area
            {
                this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            }
            if (transform.localRotation.eulerAngles.z > 180 && transform.localRotation.eulerAngles.z <= 270)//up right area
            {
                this.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            }
            if (transform.localRotation.eulerAngles.z > 270 && transform.localRotation.eulerAngles.z <= 359)//down right area
            {
                this.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
        }
        else
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }
    }



    //The animation stuff is a mess and needs fixing




    void changeAnimation()
    {
        animator.SetFloat("xChange", xMove);
        animator.SetFloat("yChange", yMove);
    }

    private void FixedUpdate()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");
        if (xMove != 0 || yMove != 0)
        {
            //this.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);//debug
            changeAnimation();
            animator.SetBool("walking", true); // set walking to true
            //walkingSound.UnPause();

        }
        // If no movement, no walking animation is needed
        else
        {
            //this.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);//debug
            animator.SetBool("walking", false);
            //walkingSound.Pause();
        }
    }
    // Update is called once per frame
    void Update()
    {
        rotationStablizer();
        animationChangerDirectionColorTest();
    }
}
