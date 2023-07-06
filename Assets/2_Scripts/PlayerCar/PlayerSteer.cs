using UnityEngine;

public class PlayerSteer : MonoBehaviour
{
    [SerializeField] private Player _car;
    
    private void Update()
    {
        _car.SyncPositionToSphere(transform);

        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveVertical < 0)
            moveHorizontal *= -1;

        float sphereVelocity = Mathf.Clamp(_car.SphereRigidbody.velocity.magnitude, 0, _car.MaxTurnThreshold);
        float rotationMultiplier = sphereVelocity / _car.MaxTurnThreshold;

        transform.Rotate(0f, moveHorizontal * _car.RotationSpeed * rotationMultiplier, 0f);
    }
}
