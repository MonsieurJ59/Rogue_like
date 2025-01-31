using UnityEngine;

public class KeepRotationZero : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
