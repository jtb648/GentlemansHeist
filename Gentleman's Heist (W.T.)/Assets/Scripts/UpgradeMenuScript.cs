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

    [SerializeField] 
    private GameObject noMoneyPanel;
    
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
        if(purchaseItem(silentShoesPrice))
        {
            PlayerData.SetSilentShoes(4);
        }
    }

    public void buyLockpick(){
        // For now, buying a lockpick just adds another key to PlayerData
        if(purchaseItem(lockPickPrice))
        {
            PlayerData.SetKeys();
        }
    }

    public void buySilentWeapon(){
        // [Add SilentWeapon to inventory here(?)]
        purchaseItem(silentWeaponPrice);
    }

    public void buyCoffee(){
        if(purchaseItem(coffeePrice))
        {
            PlayerData.SetUpgradeCoffee();
        }
    }

    public void buyAlarmDisabler(){
        purchaseItem(alarmDisablerPrice);
    }

    public void buyFood(){
        if(purchaseItem(foodPrice))
        {
            PlayerData.SetUpgradeFood();
        }
    }

    private bool purchaseItem(int Price){
        int money = PlayerData.GetMoney() - Price;
        if(money < 0){
            youHaveNoMoney();
            return false;
        }
        else {
            PlayerData.SetMoney(money);
            earnings.text = "Earnings: " + money;
            return true;
        }
    }

    public void youHaveNoMoney(){
        noMoneyPanel.SetActive(true);
    }

}
