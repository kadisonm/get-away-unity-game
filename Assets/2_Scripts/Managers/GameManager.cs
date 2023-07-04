using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float RoundTime;

    private enum GameState
    {
        Menu,
        Playing,
    }

    private GameState CurrentState;

    private float TimeRemaining;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        BeginRound();
    }

    private void Update()
    {
        if (CurrentState == GameState.Playing)
        {
            UpdateRound();
        }
        
    }

    private void BeginRound()
    {
        CurrentState = GameState.Playing;
        TimeRemaining = RoundTime;
    }

    private void UpdateRound()
    {
        if (TimeRemaining > 0)
        {
            RoundTime -= Time.deltaTime;
        }
        else
        {

        }
    }
}
