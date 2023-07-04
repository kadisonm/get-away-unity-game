using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform PlayerSphere;

    public Transform Spawn;

    public enum Personality
    {
        Smart,
        Passive,
        Dumb,
        Aggressive
    }

    [Header("Personality")]
    public Personality AIPersonality;
    public Vector3 TargetPosition;
    public PlayerSteer PlayerDirection;

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

    public void OnAwake()
    {
        AIPersonality = (Personality)Random.Range(0, 3);
    }

    public void Update()
    {
        Debug.Log(PlayerSphere.transform.position);
        if (AIPersonality == Personality.Smart)
        {
            TargetPosition = PlayerSphere.transform.position + (PlayerDirection.transform.forward * 2);
        }
        else if (AIPersonality == Personality.Passive)
        {
            TargetPosition = PlayerSphere.transform.position - (PlayerDirection.transform.forward * 2);
        }
        else if (AIPersonality == Personality.Dumb)
        {
            TargetPosition = PlayerSphere.transform.position + new Vector3(Random.Range(-3, 3), PlayerSphere.transform.position.y, Random.Range(-3, 3));
        }
        else if (AIPersonality == Personality.Aggressive)
        {
            TargetPosition = PlayerSphere.transform.position;
        }
    }
}
