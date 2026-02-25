using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.gameObject.name);
    }
}
