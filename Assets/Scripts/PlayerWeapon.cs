using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance;

    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        foreach (var laser in lasers)
        {
            var emission = laser.GetComponent<ParticleSystem>().emission;
            emission.enabled = isFiring;
        }
        if (Mouse.current != null)
        {

            var mousePosition = Mouse.current.position.ReadValue();
            crosshair.position = mousePosition;

            Vector3 targetPointPosition = new Vector3(mousePosition.x, mousePosition.y, targetDistance);

            targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
        }

        foreach (var laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }

    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
}
