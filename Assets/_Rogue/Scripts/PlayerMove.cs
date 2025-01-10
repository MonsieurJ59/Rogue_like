using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb;
    Vector2 _dir;

    void Start(){
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 dirNormalized = _dir.normalized;
        _rb.MovePosition(_rb.position + dirNormalized * GameManager._gameManager._playerStats.GetSpeed() * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        _dir = value.Get<Vector2>();
    }
}
