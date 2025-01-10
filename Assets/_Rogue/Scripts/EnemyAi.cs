using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    NavMeshAgent _agent;
    Transform _player;

    void Start()
    {
        _player = GameManager._gameManager._player.transform;
        _agent = this.gameObject.GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    void Update()
    {
        _agent.SetDestination(_player.position);
    }
}
