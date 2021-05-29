using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LinearColorChanger : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Color _targetColor;
    
    private SpriteRenderer Target;
    private float _runningTime;
    private Color _startColor;

    private void Start()
    {
        Target = GetComponent<SpriteRenderer>();
        _startColor = Target.color;
    }
    private void Update()
    {
        if(_runningTime <= _duration)
        {
            _runningTime += Time.deltaTime;

            float normalizeRunningTime = _runningTime / _duration;

            Target.color = Color.Lerp(_startColor, _targetColor, normalizeRunningTime);
        }
    }
}