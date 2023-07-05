using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heist : MonoBehaviour
{
    private enum HeistState
    {
        Cooldown,
        Rolling,
        InProgress,
    }

    public int EarnableMoney;
    public int AvailabilityTime;
    public int Cooldown;
    public int RollInterval;

    [HideInInspector] public bool inProgress;

    [Range(0, 10)][SerializeField] private int _robberyChance;

    [SerializeField] private HeistState _state = HeistState.Cooldown;
    private float _cooldownTimer;
    private float _rollTimer;
    private float _progressTimer;

    private void Update()
    {
        if (GameManager.Instance.CurrentState != GameManager.GameState.Playing)
            return;

        if (_state == HeistState.Cooldown)
        {
            CooldownState();
        }
        else if (_state == HeistState.Rolling)
        {
            RollingState();
        }
        else if (_state == HeistState.InProgress)
        {
            InProgressState();
        }
    }

    private void CooldownState()
    {
        if (_cooldownTimer < Cooldown)
        {
            _cooldownTimer += Time.deltaTime;
            return;
        }

        _cooldownTimer = 0;
        _state = HeistState.Rolling;
    }

    private void RollingState()
    {
        if (_rollTimer < RollInterval)
        {
            _rollTimer += Time.deltaTime;
            return;
        }

        _rollTimer = 0;

        float chance = Random.Range(0, 10);

        if (chance <= _robberyChance)
        {
            _state = HeistState.InProgress;
        }
    }

    private void InProgressState()
    {
        if (_progressTimer < AvailabilityTime)
        {
            _progressTimer += Time.deltaTime;
            inProgress = true;

            return;
        }

        inProgress = false;
        _progressTimer = 0;
        _state = HeistState.Cooldown;
    }

    public float RobPlace()
    {
        if (_state == HeistState.InProgress)
        {
            inProgress = false;
            _progressTimer = 0;
            _state = HeistState.Cooldown;

            return EarnableMoney;
        } 
        else
        {
            return 0;
        }
    }
}
