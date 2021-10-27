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

    // The speed the player moves
    public float speed = 10.0f;

    // Reduce value used for diagonal movement
    public float reduce = 1.2f;

    // The limits the player can move up, down, left, and right
    private float yBoundTop = 13.8f;
    private float yBoundBottom = -13.1f;
    private float xBoundLeft = -32.5f;
    private float xBoundRight = 27.8f;

    // Reference to the Player's animator
    // --> Animator must include xChange, yChange, and walking as its parameters (i can set this up soon)
    public Animator animator;
    
    // Reference to the Player's rigid body
    public Rigidbody2D myBody;

    // Interactable Object within the Player's collision radius
    public GameObject currentInteractableObject = null;
    // Start is called before the first frame update
    void Start()
    {

    }

 // Update is called once per frame
    void FixedUpdate()
    {
        // Gather the Keyboard Input from WASD or Arrow Keys
        // --> The x and y values for the player to move to
        xMove = Input.GetAxisRaw("Horizontal");;
        yMove = Input.GetAxisRaw("Vertical");

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

        // Diagonal Movement
        // --> If x and y are both moving, then player will move diagonal
        if(xMove != 0 && yMove != 0)
        {
            // (I wholeheartly believe there is a better way to do this, but it works)
            // reduced speed on the diagonal, since it moves too fast with regular speed
            transform.position += new Vector3(xMove * speed/reduce * Time.deltaTime, yMove * speed/reduce * Time.deltaTime, 0);
            changeAnimation();
            animator.SetBool("walking", true); // set walking to true
        }
        // Right/Left or Up/Down movement
        // --> If only x or y is moving, then speed can be regular
        else if(xMove != 0 || yMove != 0)
        {
            transform.position += new Vector3(xMove, yMove, 0) * speed * Time.deltaTime;
            changeAnimation();
            animator.SetBool("walking", true); // set walking to true
        }
        // If no movement, no walking animation is needed
        else
        {
            animator.SetBool("walking", false);
        }

        //Interacting with a pickup 
        if (Input.GetKeyDown(KeyCode.E) && currentInteractableObject){
            currentInteractableObject.SendMessage("DoInteraction");
        }
    }

    // Updates the animation BlendTree
    void changeAnimation()
    {
            animator.SetFloat("xChange", xMove);
            animator.SetFloat("yChange", yMove);
    }
    // Marks an interactable object as the current interactable object when entering their collision area
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("InteractableObject")){
            Debug.Log(collision.name);
            currentInteractableObject = collision.gameObject;
          
        }
    }
    // Unmarks an interactable object as the current interactable object when exiting their collision area
   private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("InteractableObject")){
            Debug.Log(collision.name);
            currentInteractableObject = null;
           
        }
    }
}
