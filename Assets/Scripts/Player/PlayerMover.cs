using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _runSpeed = 5f;
    [SerializeField] private float _jumpForce = 7f;

    [SerializeField] private AnimationChanger _animationChanger;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;

    private bool _onGround;
    private bool _isRunning;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _isRunning = false;
        _onGround = true;
    }

    private void OnEnable()
    {
        if(_groundChecker != null)
        _groundChecker.GroundStateChanged += UpdateGroundState;
    }

    private void OnDisable()
    {
        if (_groundChecker != null)
            _groundChecker.GroundStateChanged -= UpdateGroundState;
    }

    public void Move(float direction)
    {
        bool isMove;

        float currentSpeed = _walkSpeed;

        if (_isRunning)
            currentSpeed = _runSpeed;

        _rigidbody.velocity = new Vector2(direction * currentSpeed, _rigidbody.velocity.y);

        isMove = direction != 0f;

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

    private void UpdateGroundState(bool onGround)
    {
        _onGround = onGround;
        _animationChanger.OnGroundStateChanged(onGround);
    }
}
