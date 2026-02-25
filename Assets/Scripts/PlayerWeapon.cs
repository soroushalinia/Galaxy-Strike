using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] ParticleSystem laser;

    bool isFiring = false;
    ParticleSystem.EmissionModule emission;

    void Start()
    {
        emission = laser.emission;
    }

    void Update()
    {
        emission.enabled = isFiring;
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
}
