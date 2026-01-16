using UnityEngine;

public static class PlayerAnimatorData
{
    public static class Params
    {
        public static readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));
        public static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
        public static readonly int OnGround = Animator.StringToHash(nameof(OnGround));
    }
}
