using System.Collections.Generic;
using UnityEngine;

public class CurseSystem : MonoBehaviour
{

    [Header("Heath Settings")]
    private int _nbCursedHealth = 0;
    public int _CurseHealth;

    [Header("Speed Settings")]
    private int _nbCursedSpeed = 0;
    public float _CurseSpeed;

    [Header("Shotter Settings")]
    private int _nbCursedCd = 0;
    public float _CurseCd;
    private int _nbCursedDommage = 0;
    public int _CurseDommage;
    private int _nbCursedBulletSpeed = 0;
    public float _CurseBulletSpeed;


    public void CurseHealth()
    {
        _nbCursedHealth ++;
        UpdateCurseHealth();
    }
    public void UncurseHealth()
    {
        _nbCursedHealth --;
        UpdateCurseHealth();
    }

    public void UpdateCurseHealth()
    {
        GameManager._gameManager._playerStats.SetHealth(GameManager._gameManager._playerStats._initHealth + _CurseHealth * _nbCursedHealth);
    }

    public void CurseSpeed()
    {
        _nbCursedSpeed ++;
        UpdateCurseSpeed();
    }
    public void UncurseSpeed()
    {
        _nbCursedSpeed --;
        UpdateCurseSpeed();
    }

    public void UpdateCurseSpeed()
    {
        GameManager._gameManager._playerStats.SetSpeed(GameManager._gameManager._playerStats._initSpeed + _CurseSpeed * _nbCursedSpeed);
    }

    public void CurseCd()
    {
        _nbCursedCd ++;
        UpdateCurseCd();
    }
    public void UncurseCd()
    {
        _nbCursedCd --;
        UpdateCurseCd();
    }

    public void UpdateCurseCd()
    {
        GameManager._gameManager._playerStats.SetCd(GameManager._gameManager._playerStats._initCd + _CurseCd * _nbCursedCd);
    }

    public void CurseDommage()
    {
        _nbCursedDommage ++;
        UpdateCurseDommage();
    }
    public void UncurseDommage()
    {
        _nbCursedDommage --;
        UpdateCurseDommage();
    }
    public void UpdateCurseDommage()
    {
        GameManager._gameManager._playerStats.SetDommage(GameManager._gameManager._playerStats._initDommage + _CurseDommage * _nbCursedDommage);
    }

    public void CurseBulletSpeed()
    {
        _nbCursedBulletSpeed ++;
        UpdateCurseBulletSpeed();
    }
    public void UncurseBulletSpeed()
    {
        _nbCursedBulletSpeed --;
        UpdateCurseBulletSpeed();
    }
    public void UpdateCurseBulletSpeed()
    {
        GameManager._gameManager._playerStats.SetBulletSpeed(GameManager._gameManager._playerStats._initBulletSpeed + _CurseBulletSpeed * _nbCursedBulletSpeed);
    }
}
