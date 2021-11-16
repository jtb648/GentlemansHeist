using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class UpgradeMenuScript : MonoBehaviour
{

    // ----MissionComplete-----
    // https://learn.unity.com/tutorial/working-with-textmesh-pro#5f86410eedbc2a00249a4928
    [SerializeField]    
    private TMP_Text currentScore;


    //----Upgrade Menu-----
    [SerializeField]    
    private TMP_Text earnings;
    
    void Start(){
        currentScore.text = "Current Score: " + PlayerData.GetScore();
        earnings.text = "Earnings: " + PlayerData.GetMoney();
    }

    public void ContinueNextLevel(){
        SceneManager.LoadScene("SampleScene");
    }

    public void buySilentShoes(){

    }

    public void buyLockpick(){

    }

    public void buySilentWeapon(){

    }

}
