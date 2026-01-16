using UnityEngine;

[RequireComponent (typeof(Animator))]

public class EnemyAnimationChanger : MonoBehaviour
{
    public readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangeMoveState(bool isMoving)
    {
        _animator.SetBool(IsWalking, isMoving);
    }
}
