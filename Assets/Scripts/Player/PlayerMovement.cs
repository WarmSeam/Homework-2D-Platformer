using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _runSpeed = 5f;
    [SerializeField] private float _jumpForce = 7f;

    private Rigidbody2D _rigidbody;
    private GroundChecker _groundChecker;

    public event Action<bool> Moved;
    public event Action Jumped;
    public event Action<bool> Running;

    private bool _onGround;
    private bool _isRunning;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
    }

    private void OnEnable()
    {
        if(_groundChecker != null)
        _groundChecker.GroundStateChanged += GetGroundState;
    }

    private void OnDisable()
    {
        if (_groundChecker != null)
            _groundChecker.GroundStateChanged -= GetGroundState;
    }

    public void Move(float direction)
    {
        bool isMove;

        float currentSpeed = _walkSpeed;

        if (_isRunning)
            currentSpeed = _runSpeed;

        _rigidbody.velocity = new Vector2(direction * currentSpeed, _rigidbody.velocity.y);

        if (direction != 0f)
            isMove = true;
        else
            isMove = false;

        if (direction < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (direction > 0)
            transform.localScale = new Vector3(1, 1, 1);

        Moved?.Invoke(isMove);
    }

    public void Run(bool isRunning)
    {
        if (_onGround)
        {
            _isRunning = isRunning;
            Running?.Invoke(_isRunning);
        }
    }

    public void Jump(bool isJumped)
    {
        if (isJumped && _onGround)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            Jumped?.Invoke();
        }
    }

    private void GetGroundState(bool onGround)
    {
        _onGround = onGround;
    }
}
