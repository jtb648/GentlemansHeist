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
        if (collision.gameObject.tag == "Player") {
            if (PlayerData.GetKeys() >= 1) { //Left at zero for debugging purposes, change zero to one before building
                PlayerData.ChangeKeys(PlayerData.GetKeys()-1);
                PlayerData.NextLevel();
                game.NextFloor();
                SceneManager.LoadScene("UpgradeMenu");
                SaveMaster.ClearTracking();
            }
            else {
                Debug.Log("No keys collected");
            }
        }
    }
}