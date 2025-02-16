using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector2 _dir;
    private float _speed;
    private int _dommage = 1;
    public LayerMask _collideWith;
    private CurseRoom _curseRoom;

    void Update()
    {
        transform.position += new Vector3(_dir.x , _dir.y, 0)  * _speed * Time.deltaTime;
    }

    public void Init(Vector2 dir , int dommage, float speed, CurseRoom curseRoom){
        _dir = dir;
        _dommage = dommage;
        _speed = speed;
        _curseRoom = curseRoom;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsInLayerMask(other.gameObject))
        {
            PlayerHealthSystem playerHealthSystem = other.gameObject.GetComponent<PlayerHealthSystem>();

            if(playerHealthSystem){
               playerHealthSystem.Hitted(_dommage, _curseRoom); 
            }

            Destroy(this.gameObject);
        }
    
    }

    private bool IsInLayerMask(GameObject obj)
    {
        return (_collideWith.value & (1 << obj.layer)) != 0;
    }
}
