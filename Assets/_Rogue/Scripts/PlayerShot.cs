using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShot : MonoBehaviour
{
    float _timer = 0;
    private Vector2 _dir;
    public GameObject _bullet;
    public float _distanceSpawn = 0.5f;

    public GameObject _visuelTeteLeft;
    public GameObject _visuelTeteRight;
    public GameObject _visuelTeteFace;
    public GameObject _visuelTeteDos;

    void Start()
    {
        _visuelTeteLeft.SetActive(false);
        _visuelTeteRight.SetActive(false);
        _visuelTeteFace.SetActive(true);
        _visuelTeteDos.SetActive(false);
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        if(_dir.magnitude > 0 && _timer <= 0)
        {
            _timer = GameManager._gameManager._playerStats.GetCd();
            Vector2 dirNormalized = _dir.normalized;
            Vector3 posInst = transform.position + new Vector3(dirNormalized.x * _distanceSpawn , dirNormalized.y * _distanceSpawn, 0);
            GameObject instBullet = Instantiate(_bullet, transform.position, quaternion.identity);
            instBullet.GetComponent<Bullet>().Init(_dir, GameManager._gameManager._playerStats.GetDommage(), GameManager._gameManager._playerStats.GetBulletSpeed());
        }

        if(_dir.x >= 1)
        {
            _visuelTeteLeft.SetActive(false);
            _visuelTeteRight.SetActive(true);
            _visuelTeteFace.SetActive(false);
            _visuelTeteDos.SetActive(false);
        }
        else if(_dir.x <= -1)
        {
            _visuelTeteLeft.SetActive(true);
            _visuelTeteRight.SetActive(false);
            _visuelTeteFace.SetActive(false);
            _visuelTeteDos.SetActive(false);
        }
        else if(_dir.y >= 1)
        {
            _visuelTeteLeft.SetActive(false);
            _visuelTeteRight.SetActive(false);
            _visuelTeteFace.SetActive(false);
            _visuelTeteDos.SetActive(true);
        }
        else if(_dir.y <= -1)
        {
            _visuelTeteLeft.SetActive(false);
            _visuelTeteRight.SetActive(false);
            _visuelTeteFace.SetActive(true);
            _visuelTeteDos.SetActive(false);
        }
    }

    private void OnShot(InputValue value)
    {
        _dir = value.Get<Vector2>();
    }
}
