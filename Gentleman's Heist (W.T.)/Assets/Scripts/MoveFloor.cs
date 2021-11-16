using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveFloor : MonoBehaviour
{
    Game game;

    void Start() {
        game = FindObjectOfType<Game>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (UIUpdater.keys >= 0) { //Left at zero for debugging purposes, change zero to one before building
            PlayerData.NextLevel();
            game.NextFloor();
            SceneManager.LoadScene("UpgradeMenu");
        }
        else {
            Debug.Log("No keys collected");
        }
    }
}