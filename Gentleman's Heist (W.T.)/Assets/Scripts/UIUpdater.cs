using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Workable, probably temporary, version of updating keys + score/diamonds text and displaying on a canvas.
public class UIUpdater : MonoBehaviour

{
    [SerializeField]
    private Text keys_text;
    [SerializeField]
    private Text diamonds_text;

    [SerializeField]
    private Text score_text;

    //static for now since this is how I learned but probably better ways
    public static int keys;
    //static for now since this is how I learned but probably better ways
    public static int diamonds;

    //for storing the total diamonds to use as score multiplier so when removing diamonds when buying upgrades doesn't change overall score
    public static int totalDiamonds;

    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        keys = 0;
        diamonds = 0;
        totalDiamonds = diamonds;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUIKeys(keys);
        UpdateUIDiamonds(diamonds);
        UpdateUIScore(score);
    }
    //Updates the keys text to be the new amount of keys
    public void UpdateUIKeys(int num_keys){
        keys_text.text = "" + num_keys;
    }
    //Updates the diamonds text to be the new amount of diamonds
    public void UpdateUIDiamonds(int num_diamonds){
        totalDiamonds = diamonds;
        diamonds_text.text = "" + num_diamonds;
    }
     //Updates score text to be coins picked up plus diamonds * whatever we want diamonds to be worth
    public void UpdateUIScore(int new_score){
        new_score += totalDiamonds * 500;
        score_text.text = "Score: " + new_score;
    }
}
