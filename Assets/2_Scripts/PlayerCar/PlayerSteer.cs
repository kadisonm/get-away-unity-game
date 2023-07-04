 using UnityEngine;
public class PlayerSteer : MonoBehaviour
{
    [SerializeField] private Player Car;

    private void Update()
    {
        if (transform.position != Car.SphereTransform.position)
            transform.position = Car.SphereTransform.position;

        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveVertical < 0)
            moveHorizontal *= -1;

        float sphereVelocity = Mathf.Clamp(Car.SphereRigidbody.velocity.magnitude, 0, Car.MaxTurnThreshold);
        float rotationMultiplier = sphereVelocity / Car.MaxTurnThreshold;

        transform.Rotate(0f, moveHorizontal * Car.RotationSpeed * rotationMultiplier, 0f);
    }
}
