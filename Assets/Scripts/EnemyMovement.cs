using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CapsuleCollider2D _collider;
    private Rigidbody2D _rigidbody;
    private int[]  _directionRandom  = {1, -1};
    private Vector2 _direction;
    private Vector2 _size;
    private float _bodyHalfWidth;
    private int _widthDivisionRatio = 2;
    private float _maxApproachDistance = 0.01f;
    private Vector2 _pointOnBodyBorderX;     

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();

        _size = _collider.size;
        _bodyHalfWidth = _size.x / _widthDivisionRatio;

        _direction = Vector2.left * _directionRandom[Random.Range(0, 2)];
    }

    void Update()
    {
        _pointOnBodyBorderX = _rigidbody.position + _direction * _bodyHalfWidth;

        RaycastHit2D checkGround = Physics2D.Raycast(_pointOnBodyBorderX, Vector2.down, _bodyHalfWidth);
        RaycastHit2D checkWall = Physics2D.Raycast(_pointOnBodyBorderX, _direction, _maxApproachDistance);

        if (checkWall.collider != null || checkGround.collider == null)
        {
            _direction = _direction * -1;
        }

        _rigidbody.position = _rigidbody.position + _direction * _speed * Time.deltaTime;
    }
}
