using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EnemyAnimationChanger))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _patrolSpeed = 1f;
    [SerializeField] private float _chasingSpeed = 2f;
    [SerializeField] private PlayerFinder _playerFinder;

    private Rigidbody2D _rigidbody;
    private EnemyAnimationChanger _animationChanger;

    private Vector3 _target;
    private bool _isMoving = true;
    private float _currentSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animationChanger = GetComponent<EnemyAnimationChanger>();

        _target = transform.position;
        _currentSpeed = _patrolSpeed;
    }

    private void Start()
    {
        _animationChanger.ChangeMoveState(_isMoving);
    }

    private void OnEnable()
    {
        if (_playerFinder != null)
        {
            _playerFinder.PlayerFound += OnPlayerFound;
            _playerFinder.PlayerLost += OnPlayerLost;
        }
    }

    private void OnDisable()
    {
        if (_playerFinder != null)
        {
            _playerFinder.PlayerFound -= OnPlayerFound;
            _playerFinder.PlayerLost -= OnPlayerLost;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }

    private void Move()
    {
        Vector2 direction = (_target - transform.position).normalized;
        _rigidbody.velocity = new Vector2(direction.x * _currentSpeed, _rigidbody.velocity.y);
    }

    private void OnPlayerFound(Vector3 playerPosition)
    {
        _target = playerPosition;
        _currentSpeed = _chasingSpeed;
    }

    private void OnPlayerLost()
    {
        _currentSpeed = _patrolSpeed;
    }
}
