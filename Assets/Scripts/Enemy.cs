using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject destroyedVFX;
    void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
