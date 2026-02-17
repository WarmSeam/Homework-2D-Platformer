using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class AttackReactor : MonoBehaviour
{
    [SerializeField] private AnimationChanger _animation;

    private Attacker _attack;

    private void Awake()
    {
        _attack = GetComponent<Attacker>();
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
