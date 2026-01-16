using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimationChanger : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if (_groundChecker != null)
            _groundChecker.GroundStateChanged += OnGroundStateChanged;
    }

    private void OnDisable()
    {
        if (_groundChecker != null)
            _groundChecker.GroundStateChanged -= OnGroundStateChanged;
    }

    public void ChangeWalkState(bool isMoving)
    {
        Set(PlayerAnimatorData.Params.IsWalking, isMoving);
    }

    public void ChangeRunState(bool isRunning)
    {
        Set(PlayerAnimatorData.Params.IsRunning, isRunning);
    }

    private void OnGroundStateChanged(bool onGround)
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
