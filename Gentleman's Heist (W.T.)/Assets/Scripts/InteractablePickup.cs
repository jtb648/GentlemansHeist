using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Simple interaction when a Player interacts with an interactable object.
public class InteractablePickup : MonoBehaviour
{
    //Does the interaction. Placeholder is deleting object and updating UIUpdater texts.
    public void DoInteraction(string name){
        if (name.StartsWith("Key")){
            UIUpdater.keys++;
        }
        else if(name.StartsWith("Diamond")){
            UIUpdater.diamonds++;
        }
        Destroy(gameObject);
    }
}
