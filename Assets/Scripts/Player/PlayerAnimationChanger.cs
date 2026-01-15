using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimationChanger : MonoBehaviour
{
    private const string IsWalking = "isWalking";
    private const string OnGround = "OnGround";
    private const string IsRun = "isRun";

    private Animator _animator;
    private GroundChecker _groundChecker;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
    }

    private void OnEnable()
    {
        if (_groundChecker != null)
            _groundChecker.GroundStateChanged += GetGroundState;
    }

    private void OnDisable()
    {
        if (_groundChecker != null)
            _groundChecker.GroundStateChanged -= GetGroundState;
    }

    public void ChangeWalkState(bool isWalk)
    {
        _animator.SetBool(IsWalking, isWalk);
    }

    public void ChangeRunState(bool isRun)
    {
        _animator.SetBool(IsRun, isRun);
    }

    private void GetGroundState(bool onGround)
    {
        _animator.SetBool(OnGround, onGround);
    }
}
