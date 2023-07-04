using UnityEngine;

public class PlayerTilt : MonoBehaviour
{
    [SerializeField] private Player Car;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Car.TiltAmount;

        if (transform.position != Car.SphereTransform.position)
            transform.position = Car.SphereTransform.position;

        float sphereVelocity = Mathf.Clamp(Car.SphereRigidbody.velocity.magnitude, 0, Car.MaxTiltThreshold);
        float rotationMultiplier = sphereVelocity / Car.MaxTiltThreshold;

        transform.localRotation = Quaternion.Euler(moveHorizontal * rotationMultiplier, Car.Steering.transform.localEulerAngles.y, Car.Steering.transform.localEulerAngles.z);
    }
}
