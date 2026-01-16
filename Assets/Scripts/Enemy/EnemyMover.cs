using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EnemyAnimationChanger))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private WaypointNavigator _waypointNavigator;

    private Rigidbody2D _rigidbody;
    private EnemyAnimationChanger _animationChanger;

    private Transform _target;
    private bool _isMoving = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animationChanger = GetComponent<EnemyAnimationChanger>();

        _target = null;
    }

    private void Start()
    {
        _animationChanger.ChangeMoveState(_isMoving);
    }

    private void OnEnable()
    {
        if(_waypointNavigator != null)
        _waypointNavigator.WaypointReached += ChangeTarget;
    }

    private void OnDisable()
    {
        if (_waypointNavigator != null)
            _waypointNavigator.WaypointReached -= ChangeTarget;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Vector2 direction = (_target.position - transform.position).normalized;
        _rigidbody.velocity = new Vector2(direction.x * _moveSpeed, _rigidbody.velocity.y);
    }

    private void ChangeTarget(Transform target)
    {
        _target = target;
    }

}
