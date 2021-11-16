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
        if (UIUpdater.keys >= 1) {
            SceneManager.LoadScene("UpgradeMenu");
            game.NextFloor();
        }
        else {
            Debug.Log("No keys collected");
        }
    }
}