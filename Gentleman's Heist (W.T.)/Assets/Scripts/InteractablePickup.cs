using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Simple interaction when a Player interacts with an interactable object.
public class InteractablePickup : MonoBehaviour
{
    //Does the interaction. Placeholder is deleting object.
    public void DoInteraction(){
        Destroy(gameObject);
    }
}
