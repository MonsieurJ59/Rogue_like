using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _dir;

    public GameObject _visuelCorpsLeft;
    public GameObject _visuelCorpsRight;
    public GameObject _visuelCorpsFace;
    public GameObject _visuelCorpsDos;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _visuelCorpsLeft.SetActive(false);
        _visuelCorpsRight.SetActive(false);
        _visuelCorpsFace.SetActive(true);
        _visuelCorpsDos.SetActive(false);
    }

    void FixedUpdate()
    {
        if(_dir.x >= 1)
        {
            _visuelCorpsLeft.SetActive(false);
            _visuelCorpsRight.SetActive(true);
            _visuelCorpsFace.SetActive(false);
            _visuelCorpsDos.SetActive(false);
        }
        else if(_dir.x <= -1)
        {
            _visuelCorpsLeft.SetActive(true);
            _visuelCorpsRight.SetActive(false);
            _visuelCorpsFace.SetActive(false);
            _visuelCorpsDos.SetActive(false);
        }
        else if(_dir.y >= 1)
        {
            _visuelCorpsLeft.SetActive(false);
            _visuelCorpsRight.SetActive(false);
            _visuelCorpsFace.SetActive(false);
            _visuelCorpsDos.SetActive(true);
        }
        else if(_dir.y <= -1)
        {
            _visuelCorpsLeft.SetActive(false);
            _visuelCorpsRight.SetActive(false);
            _visuelCorpsFace.SetActive(true);
            _visuelCorpsDos.SetActive(false);
        }

        _rb.linearVelocity = _dir.normalized * GameManager._gameManager._playerStats.GetSpeed();
    }

    private void OnMove(InputValue value)
    {
        _dir = value.Get<Vector2>();
    }
}
