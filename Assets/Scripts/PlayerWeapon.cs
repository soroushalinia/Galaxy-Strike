using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] GameObject[] lasers;

    bool isFiring = false;

    void Update()
    {
        foreach (var laser in lasers)
        {
            var emission = laser.GetComponent<ParticleSystem>().emission;
            emission.enabled = isFiring;
        }
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
}
