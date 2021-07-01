using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class LinearColorChanger : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Color _targetColor;
    
    private SpriteRenderer _target;
    private float _runningTime;
    private Color _startColor;

    private void Start()
    {
        _target = GetComponent<SpriteRenderer>();
        _startColor = _target.color;
    }

    private void Update()
    {
        if(_runningTime <= _duration)
        {
            _runningTime += Time.deltaTime;

            float normalizeRunningTime = _runningTime / _duration;

            _target.color = Color.Lerp(_startColor, _targetColor, normalizeRunningTime);
        }
    }
}