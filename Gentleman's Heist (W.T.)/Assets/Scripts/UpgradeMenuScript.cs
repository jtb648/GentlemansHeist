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
    [SerializeField] 
    private TMP_Text silentShoesPriceText;
    [SerializeField] 
    private TMP_Text lockPickPriceText;
    [SerializeField] 
    private TMP_Text silentWeaponPriceText;

    [SerializeField] 
    private TMP_Text coffeePriceText;
    [SerializeField] 
    private TMP_Text alarmDisablerPriceText;
    [SerializeField] 
    private TMP_Text foodPriceText;
    private int silentShoesPrice;
    private int lockPickPrice;
    private int silentWeaponPrice;
    private int coffeePrice;
    private int alarmDisablerPrice;
    private int foodPrice;
    
    void Start(){
        currentScore.text = "Current Score: " + PlayerData.GetScore();
        earnings.text = "Earnings: " + PlayerData.GetMoney();
        // Setting Prices and Button Text
        lockPickPrice = 300;
        lockPickPriceText.text = "" + lockPickPrice;
        silentShoesPrice = 400;
        silentShoesPriceText.text = "" + silentShoesPrice;
        silentWeaponPrice = 500;
        silentWeaponPriceText.text = "" + silentWeaponPrice;
        coffeePrice = 200;
        coffeePriceText.text = "" + coffeePrice;
        alarmDisablerPrice = 600;
        alarmDisablerPriceText.text = "" + alarmDisablerPrice;
        foodPrice = 100;
        foodPriceText.text = "" + foodPrice;
    }

    public void ContinueNextLevel(){
        SceneManager.LoadScene("SampleScene");
    }

    public void buySilentShoes(){
        // [Add SilentShoes to inventory here(?)]
        int money = PlayerData.GetMoney() - silentShoesPrice;
        PlayerData.SetMoney(money);
        earnings.text = "Earnings: " + money;
    }

    public void buyLockpick(){
        // [Add Lockpick to inventory here(?)]
        int money = PlayerData.GetMoney() - lockPickPrice;
        PlayerData.SetMoney(money);
        earnings.text = "Earnings: " + money;
    }

    public void buySilentWeapon(){
        // [Add SilentWeapon to inventory here(?)]
        int money = PlayerData.GetMoney() - silentWeaponPrice;
        PlayerData.SetMoney(money);
        earnings.text = "Earnings: " + money;
    }

    public void buyCoffee(){
        // [Add Coffee to inventory here(?)]
        int money = PlayerData.GetMoney() - coffeePrice;
        PlayerData.SetMoney(money);
        earnings.text = "Earnings: " + money;
    }

    public void buyAlarmDisabler(){
        // [Add AlarmDisabler to inventory here(?)]
        int money = PlayerData.GetMoney() - alarmDisablerPrice;
        PlayerData.SetMoney(money);
        earnings.text = "Earnings: " + money;
    }

    public void buyFood(){
        // [Add Food to inventory here(?)]
        int money = PlayerData.GetMoney() - foodPrice;
        PlayerData.SetMoney(money);
        earnings.text = "Earnings: " + money;
    }

}
