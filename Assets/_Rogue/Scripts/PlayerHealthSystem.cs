using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealthSystem : MonoBehaviour
{

    [Header("Settings")]
    int _currentHealth;
    public Slider _healthbar;

    [Header("Effects")]
    public UnityEvent _dieEffects;
    public UnityEvent _hitEffects;
    public UnityEvent _healEffects;

    void Start()
    {
        _currentHealth = GameManager._gameManager._playerStats.GetHealth();
    }

    public void Hitted(int dommage , CurseSystem.Curse curse){
        _currentHealth -= dommage;
        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            GameManager._gameManager._curseSystem.ApplyCurse(curse);
            _dieEffects.Invoke();
        }
        _hitEffects.Invoke();
        SetHealth();
    }

    public void Healed(int heal)
    {
        _currentHealth += heal;
        if(_currentHealth > GameManager._gameManager._playerStats.GetHealth())
        {
            _currentHealth = GameManager._gameManager._playerStats.GetHealth();
        }
        _healEffects.Invoke();
        SetHealth();
    }

    void SetHealth()
    {
        if(_healthbar){
            _healthbar.value = (float) _currentHealth / (float) GameManager._gameManager._playerStats.GetHealth();
        }
    }
}
