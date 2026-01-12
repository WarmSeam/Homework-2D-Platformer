using UnityEngine;

[RequireComponent (typeof(Animator))]

public class EnemyAnimationChanger : MonoBehaviour
{
    private const string IsWalking = "isWalking";

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
