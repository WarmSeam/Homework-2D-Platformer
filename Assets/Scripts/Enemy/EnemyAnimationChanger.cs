using UnityEngine;

[RequireComponent (typeof(Animator), typeof(EnemyMovement))]

public class EnemyAnimationChanger : MonoBehaviour
{
    private const string IsWalking = "isWalking";

    private Animator _animator;
    private EnemyMovement _movement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<EnemyMovement>();
    }

    private void OnEnable()
    {
        _movement.Moved += ChangeMoveState;
    }

    private void OnDisable()
    {
        _movement.Moved -= ChangeMoveState;
    }

    private void ChangeMoveState(bool isMoving)
    {
        _animator.SetBool(IsWalking, isMoving);
    }
}
