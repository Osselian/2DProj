using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;  
    [SerializeField] private float _minGroundNormalY = .65f;
    [SerializeField] private bool _grounded;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _velocity;
    private RaycastHit2D[] _hitBuffer = new RaycastHit2D[16];
    private List<RaycastHit2D> _hitBufferList = new List<RaycastHit2D>(16);    
    private float _minimumJumpDistance = 0.25f;

    public Vector2 DeltaPosition { get; private set; }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _velocity = _rigidbody2D.velocity;    
    }

    private void Update()
    {
        _grounded = false;
        DeltaPosition = Vector2.zero;
        
        int count = _rigidbody2D.Cast(Vector2.down, _hitBuffer, _minimumJumpDistance);

        _hitBufferList.Clear();

        for (int i = 0; i < count; i++)
        {
            _hitBufferList.Add(_hitBuffer[i]);
        }

        for (int i = 0; i < _hitBufferList.Count; i++)
        {
            Vector2 currentNormal = _hitBufferList[i].normal;
            if (currentNormal.y > _minGroundNormalY)
            {
                _grounded = true;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            DeltaPosition = Vector2.left * _speed * Time.deltaTime;
            _rigidbody2D.position = _rigidbody2D.position + DeltaPosition;
        }
        if (Input.GetKey(KeyCode.D))
        {
            DeltaPosition = Vector2.right * _speed * Time.deltaTime;
            _rigidbody2D.position = _rigidbody2D.position + DeltaPosition;
        }
        if (Input.GetKey(KeyCode.Space) && _grounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }
}
