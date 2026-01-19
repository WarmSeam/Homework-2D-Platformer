using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimationChanger : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangeWalkState(bool isMoving)
    {
        Set(PlayerAnimatorData.Params.IsWalking, isMoving);
    }

    public void ChangeRunState(bool isRunning)
    {
        Set(PlayerAnimatorData.Params.IsRunning, isRunning);
    }

    public void OnGroundStateChanged(bool onGround)
    {
       Set(PlayerAnimatorData.Params.OnGround, onGround);
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
