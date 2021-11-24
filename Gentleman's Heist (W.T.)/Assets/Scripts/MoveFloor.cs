using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveFloor : MonoBehaviour
{
    Game game;

    public Sprite newSprite;

    private bool canUseStairs = false;

    void Start() {
        game = FindObjectOfType<Game>();
    }

    void Update() {
        if (PlayerData.GetKeys() >= 1) {
            this.GetComponent<SpriteRenderer>().sprite = newSprite;
            canUseStairs = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            if (canUseStairs) {
                PlayerData.ChangeKeys(PlayerData.GetKeys()-1);
                PlayerData.NextLevel();
                game.NextFloor();
                SceneManager.LoadScene("UpgradeMenu");
            }
            else {
                Debug.Log("No keys collected");
            }
        }
    }
}