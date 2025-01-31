using System.Collections.Generic;
using UnityEngine;

public class CurseSystem : MonoBehaviour
{
    public enum Curse
    {
        Health,
        Speed,
        Cooldown,
        Damage,  
        BulletSpeed
    }


    [Header("Heath Settings")]
    [SerializeField] private int _nbCursedHealth = 0;
    public int _CurseHealth;

    [Header("Speed Settings")]
    [SerializeField] private int _nbCursedSpeed = 0;
    public float _CurseSpeed;

    [Header("Shotter Settings")]
    [SerializeField] private int _nbCursedCd = 0;
    public float _CurseCd;
    [SerializeField] private int _nbCursedDommage = 0;
    public int _CurseDommage;
    [SerializeField] private int _nbCursedBulletSpeed = 0;
    public float _CurseBulletSpeed;


    public void ApplyCurse(Curse _curse){
        switch(_curse){
            case Curse.BulletSpeed :
                CurseBulletSpeed();
                break;
            case Curse.Cooldown :
                CurseCd();
                break;
            case Curse.Damage :
                CurseDommage();
                break;
            case Curse.Health :
                CurseSpeed();
                break;
            case Curse.Speed :
                CurseBulletSpeed();
                break;
        }
    }

    public void ApplyUncurse(Curse _curse){
        switch(_curse){
            case Curse.BulletSpeed :
                UncurseBulletSpeed();
                break;
            case Curse.Cooldown :
                UncurseCd();
                break;
            case Curse.Damage :
                UncurseDommage();
                break;
            case Curse.Health :
                UncurseSpeed();
                break;
            case Curse.Speed :
                UncurseBulletSpeed();
                break;
        }
    }

    void CurseHealth()
    {
        _nbCursedHealth ++;
        UpdateCurseHealth();
    }
    void UncurseHealth()
    {
        _nbCursedHealth --;
        UpdateCurseHealth();
    }

    void UpdateCurseHealth()
    {
        GameManager._gameManager._playerStats.SetHealth(GameManager._gameManager._playerStats._initHealth + _CurseHealth * _nbCursedHealth);
    }

    void CurseSpeed()
    {
        _nbCursedSpeed ++;
        UpdateCurseSpeed();
    }
    void UncurseSpeed()
    {
        _nbCursedSpeed --;
        UpdateCurseSpeed();
    }

    void UpdateCurseSpeed()
    {
        GameManager._gameManager._playerStats.SetSpeed(GameManager._gameManager._playerStats._initSpeed + _CurseSpeed * _nbCursedSpeed);
    }

    void CurseCd()
    {
        _nbCursedCd ++;
        UpdateCurseCd();
    }
    void UncurseCd()
    {
        _nbCursedCd --;
        UpdateCurseCd();
    }

    void UpdateCurseCd()
    {
        GameManager._gameManager._playerStats.SetCd(GameManager._gameManager._playerStats._initCd + _CurseCd * _nbCursedCd);
    }

    void CurseDommage()
    {
        _nbCursedDommage ++;
        UpdateCurseDommage();
    }
    void UncurseDommage()
    {
        _nbCursedDommage --;
        UpdateCurseDommage();
    }
    void UpdateCurseDommage()
    {
        GameManager._gameManager._playerStats.SetDommage(GameManager._gameManager._playerStats._initDommage + _CurseDommage * _nbCursedDommage);
    }

    void CurseBulletSpeed()
    {
        _nbCursedBulletSpeed ++;
        UpdateCurseBulletSpeed();
    }
    void UncurseBulletSpeed()
    {
        _nbCursedBulletSpeed --;
        UpdateCurseBulletSpeed();
    }
    void UpdateCurseBulletSpeed()
    {
        GameManager._gameManager._playerStats.SetBulletSpeed(GameManager._gameManager._playerStats._initBulletSpeed + _CurseBulletSpeed * _nbCursedBulletSpeed);
    }
}
