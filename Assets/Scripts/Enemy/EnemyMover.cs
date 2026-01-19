using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EnemyAnimationChanger))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;

    private Rigidbody2D _rigidbody;
    private EnemyAnimationChanger _animationChanger;

    private Vector3 _target;
    private bool _isMoving = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animationChanger = GetComponent<EnemyAnimationChanger>();

        _target = transform.position;
    }

    private void Start()
    {
        _animationChanger.ChangeMoveState(_isMoving);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 direction = (_target - transform.position).normalized;
        _rigidbody.velocity = new Vector2(direction.x * _moveSpeed, _rigidbody.velocity.y);
    }

    public void TakeTarget(Vector3 target)
    {
        _target = target;
    }

}
