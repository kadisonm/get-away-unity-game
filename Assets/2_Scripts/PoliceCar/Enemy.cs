using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Player;

    [Header("Tilt")]
    public float TiltAmount;
    public float MaxTiltThreshold;

    [Header("Sphere Object and Rigidbody")]
    public Transform SphereTransform;
    public Rigidbody SphereRigidbody;

    [Header("Steering")]
    public GameObject SteerObject;
    public EnemySteering Steering;
    public float RotationSpeed;
    public float MaxTurnThreshold;

    [Header("Movement")]
    public EnemyMove Movement;
    public float Acceleration;
    public float MaxSpeed;
    public float MaxReverseSpeed;

    [Header("Pathfinding")]
    public float CalculationRate;

    public void SyncPositionToSphere(Transform transform)
    {
        if (transform.position != SphereTransform.position)
            transform.position = SphereTransform.position;
    }
}
