using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EnemyAnimationChanger))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;

    private Rigidbody2D _rigidbody;
    private WaypointNavigator _waypointNavigator;
    private EnemyAnimationChanger _animationChanger;

    private Transform _target;
    private bool _isMoving = false;

    private void Awake()
    {
        _waypointNavigator = GetComponentInChildren<WaypointNavigator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animationChanger = GetComponent<EnemyAnimationChanger>();

        _target = null;
    }

    private void FixedUpdate()
    {
        Move();
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

    public void Move()
    {
        Vector2 direction = (_target.position - transform.position).normalized;
        _rigidbody.velocity = new Vector2(direction.x * _moveSpeed, _rigidbody.velocity.y);

        bool isMoving = true;
        GetMoveInfo(isMoving);
    }

    private void ChangeTarget(Transform target)
    {
        _target = target;
    }

    private void GetMoveInfo(bool isMoving)
    {
        if (_isMoving != isMoving)
        {
            _isMoving = isMoving;
            _animationChanger.ChangeMoveState(isMoving);
        }
    }
}
