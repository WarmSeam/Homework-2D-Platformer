using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;

    private Rigidbody2D _rigidbody;
    private EndPathChecker _endPathChecker;

    private float _direction;
    private bool _isMoving = false;

    public event Action<bool> Moved;

    private void Awake()
    {
        _endPathChecker = GetComponentInChildren<EndPathChecker>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _direction = 1;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        if(_endPathChecker != null)
        _endPathChecker.EndReached += ChangeDirection;
    }

    private void OnDisable()
    {
        if (_endPathChecker != null)
            _endPathChecker.EndReached -= ChangeDirection;
    }

    public void Move()
    {
        _rigidbody.velocity = new Vector2(_direction * _moveSpeed, _rigidbody.velocity.y);

        bool isMoving = true;
        GetMoveInfo(isMoving);
    }

    private void ChangeDirection()
    {
        _direction = -_direction;

        if (_direction < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (_direction > 0)
            transform.localScale = new Vector3(1, 1, 1);
    }

    private void GetMoveInfo(bool isMovingNow)
    {
        if (_isMoving != isMovingNow)
        {
            _isMoving = isMovingNow;
            Moved?.Invoke(_isMoving);
        }
    }
}
