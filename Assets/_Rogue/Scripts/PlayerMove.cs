using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _dir;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = _dir.normalized * GameManager._gameManager._playerStats.GetSpeed();
    }

    private void OnMove(InputValue value)
    {
        _dir = value.Get<Vector2>();
    }
}
