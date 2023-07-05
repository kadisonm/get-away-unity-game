using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Rigidbody SphereRigidbody;

    [Header("Objects")]
    public GameObject Steering;
    public GameObject Sphere;

    [Header("Tilt")]
    public float TiltAmount;
    public float MaxTiltThreshold;

    [Header("Steering")]
    public float RotationSpeed;
    public float MaxTurnThreshold;

    [Header("Movement")]
    public float Acceleration;
    public float MaxSpeed;
    public float MaxReverseSpeed;

    [Header("Robbery")]
    public float ActivationDistance;

    public void SyncPositionToSphere(Transform transform)
    {
        if (transform.position != Sphere.transform.position)
            transform.position = Sphere.transform.position;
    }
    private void Awake()
    {
        SphereRigidbody = GetComponentInChildren<Rigidbody>();
    }
}
