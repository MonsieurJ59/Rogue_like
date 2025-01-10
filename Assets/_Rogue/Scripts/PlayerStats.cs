using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Health Settings")]
    public int _initHealth;
    int _health;

    [Header("Speed Settings")]
    public float _initSpeed;
    float _speed;

    [Header("Shotter Settings")]
    public float _initCd;
    float _cd;
    public int _initDommage;
    int _dommage;
    public float _initBulletSpeed;
    float _bulletSpeed;

    void Awake(){
        // Health Settings
        _health = _initHealth;

        // Speed Settings
        _speed = _initSpeed;

        // Shotter Settings
        _cd = _initCd;
        _dommage = _initDommage;
        _bulletSpeed = _initBulletSpeed;
    }

    public int GetHealth(){
        return _health;
    }

    public float GetSpeed(){
        return _speed;
    }

    public float GetCd(){
        return _cd;
    }

    public int GetDommage(){
        return _dommage;
    }

    public float GetBulletSpeed(){
        return _bulletSpeed;
    }

}
