using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{

    public int floor = 1;

    public bool playing;
    public static Game Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public void NextFloor()
    {
        GenerateDungeon.Instance.DeleteDungeon();
        GenerateDungeon.Instance.GenerateNewDungeon();
        floor++;
    }

    public void StartGame()
    {
        GenerateDungeon.Instance.GenerateNewDungeon();
        Vector2 spawnPos = GenerateDungeon.Instance.GetSpawnPos();
        playing = true;
        floor = 1;
    }
}