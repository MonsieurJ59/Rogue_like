using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShot : MonoBehaviour
{
    float _timer = 0;
    private Vector2 _dir;
    public GameObject _bullet;
    public float _distanceSpawn = 0.5f;

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
    }

    private void OnShot(InputValue value)
    {
        _dir = value.Get<Vector2>();
    }
}
