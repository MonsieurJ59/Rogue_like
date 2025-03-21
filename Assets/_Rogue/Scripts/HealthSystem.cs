using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{

    [Header("Settings")]
    public int _health;
    int _currentHealth;
    public Slider _healthbar;
    public bool _isAlive;

    [Header("Effects")]
    public UnityEvent _dieEffects;
    public UnityEvent _hitEffects;
    public UnityEvent _healEffects;

    void Start()
    {
        _currentHealth = _health;
        _isAlive = true;
    }

    public void ResetHealth(){
        _currentHealth = _health;
        _isAlive = true;
        SetHealth();
    }

    public void Hitted(int dommage){
        _currentHealth -= dommage;
        if(_currentHealth <= 0)
        {
            _dieEffects.Invoke();
            _currentHealth = 0;
            _isAlive = false;

            GetComponent<EnemyData>()._room.CheckClear();
        
        }
        _hitEffects.Invoke();
        SetHealth();
    }

    public void Healed(int heal)
    {
        _currentHealth += heal;
        if(_currentHealth > _health)
        {
            _currentHealth = _health;
        }
        _healEffects.Invoke();
        SetHealth();
    }

    void SetHealth()
    {
        if(_healthbar){
            _healthbar.value = (float) _currentHealth / (float) _health;
        }
    }
}
