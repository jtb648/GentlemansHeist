using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame(){
        Debug.Log("PLAY");
        // Switches to the first Scene here
    }

    public void QuitGame(){
        // Stops the Game -> only works once it's built
        Debug.Log("QUIT");
        Application.Quit();
    }
}
