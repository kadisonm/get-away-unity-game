using UnityEngine;

public class MeshMovement : MonoBehaviour
{
    [SerializeField] private GameObject Sphere;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private float MaxTurnThreshold;

    private Rigidbody SphereBody;

    private void Start()
    {
        SphereBody = Sphere.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position != Sphere.transform.position)
            transform.position = Sphere.transform.position;

        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveVertical < 0)
            moveHorizontal *= -1;

        float sphereVelocity = Mathf.Clamp(SphereBody.velocity.magnitude, 0, MaxTurnThreshold);
        float rotationMultiplier = sphereVelocity / MaxTurnThreshold;

        transform.Rotate(0f, moveHorizontal * RotationSpeed * rotationMultiplier, 0f);
    }
}
