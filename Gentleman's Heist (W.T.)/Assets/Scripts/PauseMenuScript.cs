using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{

    public void ResumeGame(){
        Debug.Log("RESUME");
        // switches back to players last scene
    }

    public void BackToMenu(){
        Debug.Log("BACK TO MENU");
        // SceneManager.LoadScene("MainMenu");
    }

}
