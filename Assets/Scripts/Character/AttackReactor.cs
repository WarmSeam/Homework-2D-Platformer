using System;
using UnityEngine;

[RequireComponent(typeof(Attacker), typeof(AnimationChanger))]
public class AttackReactor : MonoBehaviour
{
    private Attacker _attack;
    private AnimationChanger _animation;

    private void Awake()
    {
        _attack = GetComponent<Attacker>();
        _animation = GetComponent<AnimationChanger>();
    }

    private void OnEnable()
    {
        _attack.Attacking += OnAttacking;
    }
    private void OnDisable()
    {
        _attack.Attacking -= OnAttacking;
    }

    private void OnAttacking()
    {
        _animation.ActivateAttackTrigger();
    }
}
