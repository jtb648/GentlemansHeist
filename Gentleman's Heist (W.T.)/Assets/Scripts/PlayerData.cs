using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    
    private static int _playerMoney;
    private static int _playerScore;
    
    private static string _playerName;
    
    private static float _playerSpeed;
    private static float _playerDefaultSpeed;
    private static int _playerMaxHealth;
    private static int _playerCurrentHealth;
    private static int _playerSoundCircle;

    private static int _level = 0;

    private static int _diamonds;

    private static int _keys;

    private static Animator _playerAnimator;
    private static Rigidbody2D _playerBody;
    private static Camera _playerCamera;
    private static PlayerScript _playerScript;
    private static GameObject _player;
    private static HealthBar _playerHealthBar;
    private static EntitySound _entitySound;
    
    private static float _bulletForce;

    private static bool _upgradeCoffee;

    public static int GetMoney()
    {
        return _playerMoney;
    }
    public static void AddMoney(int toAdd)
    {
        _playerMoney += toAdd;
    }
    public static void SubMoney(int toSub)
    {
        _playerMoney -= toSub;
    }
    public static void SetMoney(int toSet)
    {
        _playerMoney = toSet;
    }

    public static int GetScore()
    {
        return _playerScore;
    }
    public static void AddScore(int toAdd)
    {
        _playerScore += toAdd;
    }
    public static void SetScore(int toSet)
    {
        _playerScore = toSet;
    }

    public static string GetName()
    {
        return _playerName;
    }
    public static void SetName(string toSet)
    {
        _playerName = toSet;
    }

    public static float GetSpeed()
    {
        return _playerSpeed;
    }
    public static void AddSpeed(float toAdd)
    {
        _playerSpeed += toAdd;
    }
    public static void SubSpeed(float toSub)
    {
        _playerSpeed -= toSub;
    }
    public static void SetSpeed(float toSet)
    {
        _playerSpeed = toSet;
    }
    public static float GetDefaultSpeed()
    {
        return _playerDefaultSpeed;
    }
    public static void SetDefaultSpeed(float toSet)
    {
        _playerDefaultSpeed = toSet;
    }
    public static void SetToDefaultSpeed()
    {
        _playerSpeed = _playerDefaultSpeed;
    }

    public static int GetMaxHealth()
    {
        return _playerMaxHealth;
    }
    public static void AddMaxHealth(int toAdd)
    {
        _playerMaxHealth += toAdd;
        UpdateHealthBar();
    }
    public static void SubMaxHealth(int toSub)
    {
        _playerMaxHealth -= toSub;
        UpdateHealthBar();
    }
    public static void SetMaxHealth(int toSet)
    {
        _playerMaxHealth = toSet;
        UpdateHealthBar();
    }

    public static int GetCurrentHealth()
    {
        return _playerCurrentHealth;
    }
    public static void SetCurrentHealth(int toSet)
    {
        _playerCurrentHealth = toSet;
        UpdateHealthBar();
    }
    public static void TakeDamage(int damageAmount)
    {
        if (_playerCurrentHealth - damageAmount < 0)
        {
            _playerCurrentHealth = 0;
        }
        else
        {
            _playerCurrentHealth -= damageAmount;
        }
        UpdateHealthBar();
    }
    public static void HealAmount(int healAmount)
    {
        if (_playerCurrentHealth + healAmount > _playerMaxHealth)
        {
            _playerCurrentHealth = _playerMaxHealth;
        }
        else
        {
            _playerCurrentHealth += healAmount;
        }
        UpdateHealthBar();
    }
    public static void FullHeal()
    {
        _playerCurrentHealth = _playerMaxHealth;
        UpdateHealthBar();
    }

    public static float GetBulletForce()
    {
        return _bulletForce;
    }
    public static void SetBulletForce(float newBulletForce)
    {
        _bulletForce = newBulletForce;
    }

    public static Animator GetAnimator()
    {
        return _playerAnimator;
    }
    public static void SetAnimator(Animator animator)
    {
        _playerAnimator = animator;
    }

    public static Rigidbody2D GetBody()
    {
        return _playerBody;
    }
    public static void SetBody(Rigidbody2D toSet)
    {
        _playerBody = toSet;
    }
    public static Vector3 Velocity()
    {
        return _playerBody.velocity;
    }

    public static Camera GetCamera()
    {
        return _playerCamera;
    }

    public static void SetCamera(Camera newCam)
    {
        _playerCamera = newCam;
    }

    public static GameObject GetPlayer()
    {
        return _player;
    }
    public static void SetPlayer(GameObject toSet)
    {
        _player = toSet;
    }

    public static PlayerScript GetPlayerScript()
    {
        return _playerScript;
    }
    public static void SetPlayerScript(PlayerScript toSet)
    {
        _playerScript = toSet;
    }

    public static HealthBar GetHealthBar()
    {
        return _playerHealthBar;
    }
    public static void SetHealthBar(HealthBar toSet)
    {
        _playerHealthBar = toSet;
    }
    public static void UpdateHealthBar()
    {
        _playerHealthBar.setHealth(GetCurrentHealth());
        // _playerHealthBar.setMaxHealth(GetMaxHealth());
    }

    public static int GetLevel()
    {
        return _level;
    }
    public static void SetLevel(int toSet)
    {
        _level = toSet;
    }

    public static void NextLevel()
    {
        _level += 1;
    }
    public static int GetDiamonds(){
        return _diamonds;
    }

    public static void SetDiamonds(){
        _diamonds++;
    }

     public static int GetKeys(){
        return _keys;
    }

    public static void SetKeys(){
        _keys++;
    }

    public static void ChangeKeys(int toSet) {
        _keys = toSet;
    }

    public static void SetSilentShoes(int newRatio)
    {
        _entitySound.transitionDivs = newRatio;
    }

    public static void SetEntitySound(EntitySound toSet)
    {
        _entitySound = toSet;
    } 

    public static void SetUpgradeCoffee(){
        if(_upgradeCoffee){
            _upgradeCoffee = false;
        }
        else{
            _upgradeCoffee = true;
        }
    }

    public static bool GetUpgradeCoffee(){
        return _upgradeCoffee;
    }
    

}
