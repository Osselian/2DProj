using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerMovement))]
public class AnimationSwitcher : MonoBehaviour
{
    private PlayerMovement _movement;
    private Animator _animator;
    private SpriteRenderer _sprite;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Speed", _movement.DeltaPosition.magnitude);

        if (_movement.DeltaPosition.x > 0)
        {
            _sprite.flipX = false;
        }
        
        if (_movement.DeltaPosition.x < 0)
        {
            _sprite.flipX = true;
        }
    }
}
