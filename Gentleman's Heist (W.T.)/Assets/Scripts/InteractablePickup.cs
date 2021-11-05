using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Simple interaction when a Player interacts with an interactable object.
public class InteractablePickup : MonoBehaviour
{
    public AudioSource coinSound;
    //Does the interaction. Placeholder is deleting object and updating UIUpdater texts.
    void Start() {
        coinSound = gameObject.GetComponent<AudioSource>();
    }
    public void DoInteraction(string name){
        
        if (name.StartsWith("Key")){
            UIUpdater.keys++;
        }
        else if(name.StartsWith("Diamond")){
            //AudioSource.PlayClipAtPoint(coinSound.clip,gameObject.transform.position);
            UIUpdater.diamonds++; 
        }
        else if(name.StartsWith("Coin")){
            AudioSource.PlayClipAtPoint(coinSound.clip,gameObject.transform.position);
            UIUpdater.score++;
        }
        Destroy(gameObject);
    }
}
