using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private Enemy _car;

    private float _elapsed;

    private NavMeshPath _path;

    private void Awake()
    {
        _elapsed = _car.CalculationRate;
        _path = new NavMeshPath();
    }

    private void Update()
    {
        _elapsed += Time.deltaTime;

        if (_elapsed <= _car.CalculationRate)
            return;

        _elapsed -= _car.CalculationRate;

        NavMesh.CalculatePath(_car.Sphere.transform.position, _car.TargetPosition, NavMesh.AllAreas, _path);
        
        if (_path.corners.Length > 0)
            _car.SteeringController.LookTowards(_path.corners[1]);
    }
}
