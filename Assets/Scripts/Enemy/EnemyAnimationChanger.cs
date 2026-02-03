using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimationChanger : MonoBehaviour
{
    private Animator _animator;
    private HealthHandler _healthHandler;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _healthHandler = GetComponent<HealthHandler>();
    }

    private void OnEnable()
    {
        _healthHandler.HealthOver += ChangeDeathState;
        _healthHandler.HealthDecreased += ActivateHitState;
    }

    private void OnDisable()
    {
        _healthHandler.HealthOver -= ChangeDeathState;
        _healthHandler.HealthDecreased -= ActivateHitState;
    }

    public void ChangeMoveState(bool isMoving)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsWalking, isMoving);
    }

    public void ChangeDeathState(bool isDied)
    {
        _animator.SetBool(PlayerAnimatorData.Params.isDied, isDied);
    }

    public void ActivateHitState(int value)
    {
        if(value > 0)
        _animator.SetTrigger(PlayerAnimatorData.Params.Hurt);
    }
}
