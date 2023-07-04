using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private Enemy Car;

    private float Elapsed;

    private NavMeshPath Path;

    private void Awake()
    {
        Elapsed = Car.CalculationRate;
        Path = new NavMeshPath();
    }

    private void Update()
    {
        Elapsed += Time.deltaTime;

        if (Elapsed <= Car.CalculationRate)
        {
            return;
        }

        Elapsed -= Car.CalculationRate;

        NavMesh.CalculatePath(Car.SphereTransform.position, Car.Player.position, NavMesh.AllAreas, Path);
        
        for (int i = 1; i < Path.corners.Length; ++i)
        {
            Debug.DrawLine(Path.corners[i - 1], Path.corners[i], Color.green, Car.CalculationRate);
        }

        if (Path.corners.Length > 0)
            Car.Steering.LookTowards(Path.corners[1]);

        Car.Movement.StartMotor();
    }
}
