using Unity.Mathematics;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float _cd;
    float _timer = 0;
    public GameObject _bullet;
    public float _distanceSpawn = 0.5f;
    public int _dommage = 1;
    public LayerMask _collideWith;


    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if(_timer <= 0)
        {
            Vector3 posPlayer = GameManager._gameManager._player.transform.position;
            Vector2 dir = new Vector2(posPlayer.x - transform.position.x, posPlayer.y - transform.position.y).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, Mathf.Infinity, _collideWith);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                _timer = _cd;
                Vector3 posInst = transform.position + new Vector3(dir.x * _distanceSpawn, dir.y * _distanceSpawn, 0);
                GameObject instBullet = Instantiate(_bullet, transform.position, Quaternion.identity);
                instBullet.GetComponent<EnemyBullet>().Init(dir, _dommage, 5, GetComponent<EnemyData>()._room._curseRoom);
            }
        }
    }
    
}
