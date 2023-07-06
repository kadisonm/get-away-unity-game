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

    [HideInInspector]  public string Announcement;

    [HideInInspector] public bool InProgress;

    [Range(0, 10)][SerializeField] private int _robberyChance;

    private HeistState _state = HeistState.Cooldown;
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

            Announcement = "Cooldown<br>" + Mathf.Round(Cooldown - _cooldownTimer);

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

            Announcement = "No Heist In Progress";

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
            InProgress = true;

            Announcement = "Heist in progress!<br>" + Mathf.Round(AvailabilityTime - _progressTimer);

            return;
        }

        InProgress = false;
        _progressTimer = 0;
        _state = HeistState.Cooldown;
    }

    public float RobPlace()
    {
        if (_state == HeistState.InProgress)
        {
            InProgress = false;
            _progressTimer = 0;
            _state = HeistState.Cooldown;

            return EarnableMoney;
        } 
        else
        {
            return 0;
        }
    }

    public string GetTimer()
    {
        float remainingTime = Mathf.Round(Cooldown - _cooldownTimer);

        return "" + remainingTime;
    }
}
