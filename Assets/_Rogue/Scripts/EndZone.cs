using UnityEngine;
using UnityEngine.Events;

public class EndZone : MonoBehaviour
{
    public UnityEvent _unityEvent;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player"){
            _unityEvent.Invoke();
        }
    }
}
