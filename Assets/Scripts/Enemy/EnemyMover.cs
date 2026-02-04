using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AnimationChanger))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _patrolSpeed = 1f;
    [SerializeField] private float _chasingSpeed = 2f;

    private Rigidbody2D _rigidbody;
    private AnimationChanger _animationChanger;

    private Vector3 _target;
    private bool _isMoving = true;
    private float _currentSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animationChanger = GetComponent<AnimationChanger>();

        _target = transform.position;
        _currentSpeed = _patrolSpeed;
    }

    private void Start()
    {
        _animationChanger.ChangeWalkState(_isMoving);
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }

    public void SpeedUp(Vector3 playerPosition)
    {
        _target = playerPosition;
        _currentSpeed = _chasingSpeed;
    }

    public void SlowDown()
    {
        _currentSpeed = _patrolSpeed;
    }

    private void Move()
    {
        Vector2 direction = (_target - transform.position).normalized;
        _rigidbody.velocity = new Vector2(direction.x * _currentSpeed, _rigidbody.velocity.y);
    }
}
