using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance { get; private set; }

    [Header("Spawns")]
    public List<GameObject> Spawns;

    [Header("Stages and Enemy Stage")]
    public float SpawnFrequency;
    public float MaxEnemies;

    [Header("Stages and Enemy Stage")]
    public List<float> Stages;
    public List<GameObject> EnemiesAtStage;

    public List<GameObject> possibleEnemies = new List<GameObject>();

    private float _spawnTimer;
    public int _enemyCount;
    public int _currentEnemy;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        _spawnTimer = 0;
    }

    private void Update()
    {
        if (_enemyCount >= MaxEnemies)
            return;

        if (_spawnTimer < SpawnFrequency)
        {
            _spawnTimer += Time.deltaTime;

            return;
        }

        _spawnTimer = 0;

        float timeElapsed = GameManager.Instance.ElapsedRoundTime;

        for (int i = 0; i < EnemiesAtStage.Count; i++)
        {
            if (timeElapsed >= Stages[i])
                _currentEnemy = i;
        }

        GameObject enemy = EnemiesAtStage[_currentEnemy];

        int index = Random.Range(0, Spawns.Count);
        GameObject spawn = Spawns[index];

        _enemyCount ++;

        Instantiate(enemy, spawn.transform);
    }
}
