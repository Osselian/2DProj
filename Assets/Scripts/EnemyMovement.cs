using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float _speed;

    private CapsuleCollider2D _collider;
    private Rigidbody2D _rigidbody;
    private int[]  _directionRandom  = {1, -1};
    private Vector2 _direction;
    private Vector2 _size;
    private Vector2 _castPoint;     

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();

        _size = _collider.size;

        _direction = Vector2.left * _directionRandom[Random.Range(0, 2)];
    }

    void Update()
    {
        _castPoint = _rigidbody.position + _direction * _size.x / 2;

        RaycastHit2D checkGround = Physics2D.Raycast(_castPoint, Vector2.down, _size.x / 2);
        RaycastHit2D checkWall = Physics2D.Raycast(_castPoint, _direction, _size.x / 10);

        if (checkWall.collider != null || checkGround.collider == null)
        {
            _direction = _direction * -1;
        }

        _rigidbody.position = _rigidbody.position + _direction * _speed * Time.deltaTime;
    }
}
