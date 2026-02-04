using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationChanger : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangeWalkState(bool isMoving)
    {
        Set(AnimatorData.Params.IsWalking, isMoving);
    }

    public void ChangeRunState(bool isRunning)
    {
        Set(AnimatorData.Params.IsRunning, isRunning);
    }

    public void OnGroundStateChanged(bool onGround)
    {
       Set(AnimatorData.Params.OnGround, onGround);
    }

    public void ChangeDeathState(bool isDied)
    {
        Set(AnimatorData.Params.isDied, isDied);
    }

    public void ActivateHurtTrigger()
    {
        _animator.SetTrigger(AnimatorData.Params.Hurt);
    }

    public void ActivateAttackTrigger()
    {
        _animator.SetTrigger(AnimatorData.Params.Attack);
    }

    private void Set(int parameter, bool isEnabled)
    {
        if (isEnabled)
            Enable(parameter);
        else
            Disable(parameter);
    }

    private void Enable(int parameter)
    {
        _animator.SetBool(parameter, true);
    }

    private void Disable(int parameter)
    {
        _animator.SetBool(parameter, false);
    }
}
