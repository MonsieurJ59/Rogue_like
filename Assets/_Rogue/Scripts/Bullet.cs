using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 _dir;
    private float _speed;
    private int _dommage = 1;
    public LayerMask _collideWith;

    void Update()
    {
        transform.position += new Vector3(_dir.x , _dir.y, 0)  * _speed * Time.deltaTime;
    }

    public void Init(Vector2 dir , int dommage, float speed){
        _dir = dir;
        _dommage = dommage;
        _speed = speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsInLayerMask(other.gameObject))
        {
            HealthSystem healthSystem = other.gameObject.GetComponent<HealthSystem>();

            if(healthSystem){
               healthSystem.Hitted(_dommage); 
            }

            Destroy(this.gameObject);
        }
    
    }

    private bool IsInLayerMask(GameObject obj)
    {
        return (_collideWith.value & (1 << obj.layer)) != 0;
    }
}
