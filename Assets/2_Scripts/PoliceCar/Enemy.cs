using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum Personality
    {
        Smart,
        Passive,
        Dumb,
        Aggressive
    }

    [HideInInspector] public Transform Spawn;
    [HideInInspector] public Transform PlayerSphere;
    [HideInInspector] public Transform PlayerSteer;
    [HideInInspector] public Vector3 TargetPosition;
    [HideInInspector] public EnemySteering SteeringController;
    [HideInInspector] public Rigidbody SphereRigidbody;

    [Header("Objects")]
    public GameObject Player;
    public GameObject Steering;
    public GameObject Sphere;

    [Header("Personality")]
    public Personality AIPersonality;
    public bool Randomise;
    public float CutOffAmount;

    [Header("Steering")]
    public float RotationSpeed;

    [Header("Movement")]
    public float Acceleration;
    public float MaxSpeed;
    public float MaxReverseSpeed;

    [Header("Pathfinding")]
    public float CalculationRate;

    public void SyncPositionToSphere(Transform transform)
    {
        if (transform.position != Sphere.transform.position)
            transform.position = Sphere.transform.position;
    }

    private void Awake()
    {
        SphereRigidbody = GetComponentInChildren<Rigidbody>();
        SteeringController = GetComponentInChildren<EnemySteering >();
        PlayerSphere = Player.GetComponent<Player>().Sphere.transform;
        PlayerSteer = Player.GetComponent<Player>().Steering.transform;
    }

    private void OnEnable()
    {
        if (Randomise == true)
        { 
            AIPersonality = (Personality)Random.Range(0, 3);
        }
    }

    private void Update()
    {
        if (AIPersonality == Personality.Smart)
        {
            TargetPosition = PlayerSphere.position + (-PlayerSteer.forward * CutOffAmount);
        }
        else if (AIPersonality == Personality.Passive)
        {
            TargetPosition = PlayerSphere.position + (PlayerSteer.forward * CutOffAmount);
        }
        else if (AIPersonality == Personality.Dumb)
        {
            TargetPosition = PlayerSphere.position + new Vector3(Random.Range(-3, 3), PlayerSphere.position.y, Random.Range(-3, 3));
        }
        else if (AIPersonality == Personality.Aggressive)
        {
            TargetPosition = PlayerSphere.position;
        }
    }
}
