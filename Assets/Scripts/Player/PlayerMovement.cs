using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerAnimationChanger))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _runSpeed = 5f;
    [SerializeField] private float _jumpForce = 7f;

    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;
    private PlayerAnimationChanger _animationChanger;

    private bool _onGround;
    private bool _isRunning;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animationChanger = GetComponent<PlayerAnimationChanger>();

        _isRunning = false;
        _onGround = true;
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

        _animationChanger.ChangeWalkState(isMove);
    }

    public void Run(bool isRunning)
    {
        if (_onGround)
        {
            _isRunning = isRunning;
            _animationChanger.ChangeRunState(_isRunning);
        }
    }

    public void Jump(bool isJumped)
    {
        if (isJumped && _onGround)
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void GetGroundState(bool onGround)
    {
        _onGround = onGround;
    }
}
