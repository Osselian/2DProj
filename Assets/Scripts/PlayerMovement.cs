using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{    
    public Vector2  DeltaPosition { get; private set; }

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;  
    [SerializeField] private float _minGroundNormalY = .65f;
    [SerializeField] private bool _grounded;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _velocity;
    private RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    private List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);    
    private float _minimumJumpDistance = 0.25f;    

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _velocity = _rigidbody2D.velocity;    
    }

    private void Update()
    {
        _grounded = false;
        DeltaPosition = Vector2.zero;
        
        int count = _rigidbody2D.Cast(Vector2.down, hitBuffer, _minimumJumpDistance);

        hitBufferList.Clear();

        for (int i = 0; i < count; i++)
        {
            hitBufferList.Add(hitBuffer[i]);
        }

        for (int i = 0; i < hitBufferList.Count; i++)
        {
            Vector2 currentNormal = hitBufferList[i].normal;
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
