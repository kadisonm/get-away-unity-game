using UnityEngine;

public class PlayerSteer : MonoBehaviour
{
    [SerializeField] private float RotationSpeed;
    [SerializeField] private float MaxTurnThreshold;

    [SerializeField] private Transform Sphere;
    [SerializeField] private Rigidbody SphereRigidbody;

    private void Update()
    {
        if (transform.position != Sphere.position)
            transform.position = Sphere.position;

        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveVertical < 0)
            moveHorizontal *= -1;

        float sphereVelocity = Mathf.Clamp(SphereRigidbody.velocity.magnitude, 0, MaxTurnThreshold);
        float rotationMultiplier = sphereVelocity / MaxTurnThreshold;

        transform.Rotate(0f, moveHorizontal * RotationSpeed * rotationMultiplier, 0f);
    }
}
