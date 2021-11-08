using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*

----Player Movement Script-----

What does this script do?
- Allows player to be controlled with WASD or Arrow Keys
    --> 8 ways of movement (left, right, up, down, and all diagonals)

- Allows boundaries to be set for player
    --> This needs to be replaced with colliders, it'll make life easier (will do later)

- Allows Walking animations to be determined
    --> Using a BlendTree in Animator

*/


public class PlayerScript : MonoBehaviour
{

    // The x and y values for the player to move to
    private float xMove;
    private float yMove;

    // Player health bar
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Shooting & Crosshair/Cursor

    public GameObject crossHair;
    public Camera cam;

    public GameObject bulletPrefab;

    Vector2 mousePos;
    public float bulletForce = 20f;

    public Transform firePoint;



    // The speed the player moves
    public float speed = 10.0f;

    // evil sneak variable
    private float _sneak = 1;

    // The limits the player can move up, down, left, and right
    //Changed from 500,0,0,500 respectively
    private float yBoundTop = 999f;
    private float yBoundBottom = -999f;
    private float xBoundLeft = -999f;
    private float xBoundRight = 999f;


    // Reference to the Player's animator
    // --> Animator must include xChange, yChange, and walking as its parameters (i can set this up soon)
    public Animator animator;

    // Reference to the Player's rigid body
    public Rigidbody2D myBody;

    // Interactable Object within the Player's collision radius
    public GameObject currentInteractableObject = null;

    public AudioSource walkingSound;
    
    // Start is called before the first frame update
    void Start()
    {
      currentHealth = maxHealth;
      healthBar.setHealth(maxHealth);
      walkingSound = gameObject.GetComponent<AudioSource>();
    }

 // Update is called once per frame
    void FixedUpdate()
    {
        // Gather the Keyboard Input from WASD or Arrow Keys
        // --> The x and y values for the player to move to
        xMove = Input.GetAxisRaw("Horizontal");;
        yMove = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _sneak = 2;
        }
        else
        {
            _sneak = 1;
        }

        // Crosshair/cursor movement
        Vector2 mosPos = Input.mousePosition.normalized;
        mosPos = cam.ScreenToWorldPoint(Input.mousePosition);
        crossHair.transform.position = new Vector2(mosPos.x, mosPos.y);
    

        // Keeping Player within the Boundaries
        // --> if player is about to move past the boundaries, set the move value to 0
        if(transform.position.x + xMove <= xBoundLeft || transform.position.x + xMove >= xBoundRight)
        {
            xMove = 0;
        }
        if(transform.position.y + yMove >= yBoundTop || transform.position.y + yMove<= yBoundBottom)
        {
            yMove = 0;
        }

        // setting movement regardless of input
        Vector2 movement = new Vector2(xMove, yMove).normalized;
        myBody.velocity = movement * speed / _sneak;

        // if()
            
            
        // animation logic
        if(xMove != 0 || yMove != 0)
        {
            changeAnimation();
            animator.SetBool("walking", true); // set walking to true
            
        }
        // If no movement, no walking animation is needed
        else
        {
            animator.SetBool("walking", false);
        }

        
        
    }
    void Update(){
        //Interacting with a pickup
        if (Input.GetKeyDown(KeyCode.E) && currentInteractableObject){
            currentInteractableObject.SendMessage("DoInteraction",currentInteractableObject.name);
        }

        // Shooting animation logic
        if(Input.GetKeyDown(KeyCode.Space)){
            animator.SetBool("shooting", true); // set shooting to true
        }
        else{
             animator.SetBool("shooting", false); // set shooting to false
        }
        Shooting();

    }
    // Updates the animation BlendTree
    void changeAnimation()
    {
            animator.SetFloat("xChange", xMove);
            animator.SetFloat("yChange", yMove);
    }

    // Player damage
    void takeDamage(int damage){
      currentHealth -= damage;
      healthBar.setHealth(currentHealth);
    }
    public void addHealth(int health){
        currentHealth += health;
        healthBar.setHealth(currentHealth);
    }

    // Marks an interactable object as the current interactable object when entering their collision area
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("InteractableObject")){
            Debug.Log(collision.name);
            currentInteractableObject = collision.gameObject;

        }
    }

    // Shooting
    public void Shooting(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            animator.SetBool("shooting", true);
            Shoot();

        }

    }
    // Unmarks an interactable object as the current interactable object when exiting their collision area
   private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("InteractableObject")){
            Debug.Log(collision.name);
            currentInteractableObject = null;

        }
    }

    void Shoot(){
       GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       Rigidbody2D bullBody = bullet.GetComponent<Rigidbody2D>();
       bullBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    
}
