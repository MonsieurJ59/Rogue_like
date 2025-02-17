using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public Vector3 _initPos;
    public Room _room;
    public HealthSystem _healthSystem;
    public EnemyInvible _enemyInvisible;

    public void SetInitValues(Room room){
        _initPos = transform.position;
        _room = room;
    }
    public void InitEnemy(){
        if(_enemyInvisible)
        {
            _enemyInvisible.Init();
        }
        _healthSystem.ResetHealth();
        transform.position = _initPos;
    }
}
