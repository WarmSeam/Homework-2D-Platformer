using UnityEngine;

public static class EnemyAnimatorData
{
    public static class Params
    {
        public static readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
        public static readonly int Hurt = Animator.StringToHash(nameof(Hurt));
        public static readonly int isDied = Animator.StringToHash(nameof(isDied));
    }
}
