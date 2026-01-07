using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerMovement))]

public class PlayerAnimationChanger : MonoBehaviour
{
    private const string IsWalking = "isWalking";
    private const string OnGround = "OnGround";
    private const string IsRun = "isRun";

    private Animator _animator;
    private PlayerMovement _playerMovement;
    private GroundChecker _groundChecker;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
    }

    private void OnEnable()
    {
        _playerMovement.Moved += isMove => SetAnimatorBool(IsWalking, isMove);
        _playerMovement.Running += isRun => SetAnimatorBool(IsRun, isRun);

        if (_groundChecker != null)
            _groundChecker.GroundStateChanged += onGround => SetAnimatorBool(OnGround, onGround);
    }

    private void OnDisable()
    {
        _playerMovement.Moved -= isMove => SetAnimatorBool(IsWalking, isMove);
        _playerMovement.Running -= isRun => SetAnimatorBool(IsRun, isRun);

        if (_groundChecker != null)
            _groundChecker.GroundStateChanged -= onGround => SetAnimatorBool(OnGround, onGround);
    }

    private void SetAnimatorBool(string parameter, bool value)
    {
        _animator.SetBool(parameter, value);
    }
}
