using UnityEngine;

public class PlayerTilt : MonoBehaviour
{
    [SerializeField] private Player _car;

    void Update()
    {
        _car.SyncPositionToSphere(transform);

        float moveHorizontal = Input.GetAxis("Horizontal") * _car.TiltAmount;

        float sphereVelocity = Mathf.Clamp(_car.SphereRigidbody.velocity.magnitude, 0, _car.MaxTiltThreshold);
        float rotationMultiplier = sphereVelocity / _car.MaxTiltThreshold;

        transform.localRotation = Quaternion.Euler(_car.Steering.transform.localEulerAngles.x, _car.Steering.transform.localEulerAngles.y, moveHorizontal * rotationMultiplier);
    }
}
