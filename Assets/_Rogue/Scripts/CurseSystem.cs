using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public GameObject _ActifIconCurseHealth;
    public GameObject _InactifIconCurseHealth;
    public TextMeshProUGUI _TextNbCurseHealth;

    [Header("Speed Settings")]
    [SerializeField] private int _nbCursedSpeed = 0;
    public float _CurseSpeed;
    public GameObject _ActifIconCurseSpeed;
    public GameObject _InactifIconCurseSpeed;
    public TextMeshProUGUI _TextNbCurseSpeed;

    [Header("Shotter Settings")]
    [SerializeField] private int _nbCursedCd = 0;
    public float _CurseCd;
    public GameObject _ActifIconCurseCd;
    public GameObject _InactifIconCurseCd;
    public TextMeshProUGUI _TextNbCurseCd;
    [SerializeField] private int _nbCursedDommage = 0;
    public int _CurseDommage;
    public GameObject _ActifIconCurseDommage;
    public GameObject _InactifIconCurseDommage;
    public TextMeshProUGUI _TextNbCurseDommage;
    [SerializeField] private int _nbCursedBulletSpeed = 0;
    public float _CurseBulletSpeed;
    public GameObject _ActifIconCurseBulletSpeed;
    public GameObject _InactifIconCurseBulletSpeed;
    public TextMeshProUGUI _TextNbCurseBulletSpeed;

    public List<CurseRoom> _cursedRooms;

    void Start(){
        UpdateUI();
    }

    public void UpdateCurse(){

        _nbCursedBulletSpeed = 0;
        _nbCursedCd = 0;
        _nbCursedDommage = 0;
        _nbCursedHealth = 0;
        _nbCursedSpeed = 0;

        foreach(CurseRoom curseRoom in _cursedRooms)
        {
            switch(curseRoom._curse)
            {
                case Curse.BulletSpeed :
                    _nbCursedBulletSpeed += curseRoom._nbCurse;
                    break;
                case Curse.Cooldown :
                    _nbCursedCd += curseRoom._nbCurse;
                    break;
                case Curse.Damage :
                    _nbCursedDommage += curseRoom._nbCurse;
                    break;
                case Curse.Health :
                    _nbCursedHealth += curseRoom._nbCurse;
                    break;
                case Curse.Speed :
                    _nbCursedSpeed += curseRoom._nbCurse;
                    break;
            }
        }

        UpdateCurseHealth();
        UpdateCurseSpeed();
        UpdateCurseCd();
        UpdateCurseDommage();
        UpdateCurseBulletSpeed();

        UpdateUI();
    }

    void UpdateUI(){
        if(_nbCursedHealth > 0)
        {
            _TextNbCurseHealth.text = "" + _nbCursedHealth;
            _ActifIconCurseHealth.SetActive(true);
            _InactifIconCurseHealth.SetActive(false);
        }
        else
        {
            _TextNbCurseHealth.text = "";
            _ActifIconCurseHealth.SetActive(false);
            _InactifIconCurseHealth.SetActive(true);
        }

        if(_nbCursedBulletSpeed > 0)
        {
            _TextNbCurseBulletSpeed.text = "" + _nbCursedBulletSpeed;
            _ActifIconCurseBulletSpeed.SetActive(true);
            _InactifIconCurseBulletSpeed.SetActive(false);
        }
        else
        {
            _TextNbCurseBulletSpeed.text = "";
            _ActifIconCurseBulletSpeed.SetActive(false);
            _InactifIconCurseBulletSpeed.SetActive(true);
        }

        if(_nbCursedCd > 0)
        {
            _TextNbCurseCd.text = "" + _nbCursedCd;
            _ActifIconCurseCd.SetActive(true);
            _InactifIconCurseCd.SetActive(false);
        }
        else
        {
            _TextNbCurseCd.text = "";
            _ActifIconCurseCd.SetActive(false);
            _InactifIconCurseCd.SetActive(true);
        }

        if(_nbCursedDommage > 0)
        {
            _TextNbCurseDommage.text = "" + _nbCursedDommage;
            _ActifIconCurseDommage.SetActive(true);
            _InactifIconCurseDommage.SetActive(false);
        }
        else
        {
            _TextNbCurseDommage.text = "";
            _ActifIconCurseDommage.SetActive(false);
            _InactifIconCurseDommage.SetActive(true);
        }

        if(_nbCursedSpeed > 0)
        {
            _TextNbCurseSpeed.text = "" + _nbCursedSpeed;
            _ActifIconCurseSpeed.SetActive(true);
            _InactifIconCurseSpeed.SetActive(false);
        }
        else
        {
            _TextNbCurseSpeed.text = "";
            _ActifIconCurseSpeed.SetActive(false);
            _InactifIconCurseSpeed.SetActive(true);
        }
    }


    void UpdateCurseHealth()
    {
        GameManager._gameManager._playerStats.SetHealth(GameManager._gameManager._playerStats._initHealth + _CurseHealth * _nbCursedHealth);
    }

    void UpdateCurseSpeed()
    {
        GameManager._gameManager._playerStats.SetSpeed(GameManager._gameManager._playerStats._initSpeed + _CurseSpeed * _nbCursedSpeed);
    }

    void UpdateCurseCd()
    {
        GameManager._gameManager._playerStats.SetCd(GameManager._gameManager._playerStats._initCd + _CurseCd * _nbCursedCd);
    }

    void UpdateCurseDommage()
    {
        GameManager._gameManager._playerStats.SetDommage(GameManager._gameManager._playerStats._initDommage + _CurseDommage * _nbCursedDommage);
    }

    void UpdateCurseBulletSpeed()
    {
        GameManager._gameManager._playerStats.SetBulletSpeed(GameManager._gameManager._playerStats._initBulletSpeed + _CurseBulletSpeed * _nbCursedBulletSpeed);
    }
}
