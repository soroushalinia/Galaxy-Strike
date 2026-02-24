using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float zClampRange = 24f;
    [SerializeField] float yClampRange = 16f;

    [SerializeField] float controlPitchFactor = 20f;
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float rotationSpeed = 10f;

    Vector2 movement;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawZPos = transform.localPosition.z + xOffset;
        float clampedZPos = Mathf.Clamp(rawZPos, -zClampRange, zClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(0f, clampedYPos, clampedZPos);
    }

    void ProcessRotation()
    {
        float pitch = -controlPitchFactor * movement.y;
        float roll  = controlRollFactor * movement.x;

        Quaternion targetRotation =
            Quaternion.Euler(roll, 0f, pitch);

        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
}
