using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    Game game;

    void Start() {
        game = FindObjectOfType<Game>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        game.NextFloor();
    }
}