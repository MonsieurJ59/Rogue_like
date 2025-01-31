using System.Threading;
using UnityEngine;

public class EnemyContactDommageable : MonoBehaviour
{
    public float _cd;
    private float _timer;
    public int _dommage;
    private EnemyAI _enemyAI;

    void Start()
    {
        _enemyAI = GetComponent<EnemyAI>();
        _timer = _cd;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _cd && _enemyAI.isCollidingWithPlayer)
        {
            _timer = 0;
            CurseSystem.Curse curse = GetComponent<EnemyCurse>()._curse; 
            GameManager._gameManager._playerHealthSystem.Hitted(_dommage, curse);
        }
    
    }
}
