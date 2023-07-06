using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateCheck : MonoBehaviour
{
    [SerializeField] private int _frameRate;

    private void Start()
    {
        Application.targetFrameRate = _frameRate;
    }
}
