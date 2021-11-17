using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrisonMenuScript : MonoBehaviour
{
    
    public void EscapePrison(){
        // Starts player at beginning
        PlayerData.SetLevel(0);
        // Loads SampleScene
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame(){
        // Stops the Game -> only works once it's built
        Application.Quit();
    }

}
