using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public PlayerScript player;

    public int floor = 1;

    public bool playing;
    public static Game Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        GenerateDungeon.Instance.GenerateNewDungeon();
        Vector2 spawnPos = GenerateDungeon.Instance.GetSpawnPos();
        //PlayerScript p = Instantiate(player, spawnPos, Quaternion.identity);
        Vector3 spawnPos3 = spawnPos;
        player.transform.position = spawnPos3;
        //MainCameraScript.Instance.SetPlayer(p);
    }
}