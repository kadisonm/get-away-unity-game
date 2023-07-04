using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Tilt")]
    public float TiltAmount;
    public float MaxTiltThreshold;

    [Header("Sphere Object and Rigidbody")]
    public Transform SphereTransform;
    public Rigidbody SphereRigidbody;

    [Header("Steering")]
    public GameObject Steering;
    public float RotationSpeed;
    public float MaxTurnThreshold;

    [Header("Movement")]
    public float Acceleration;
    public float MaxSpeed;
    public float MaxReverseSpeed;
}
