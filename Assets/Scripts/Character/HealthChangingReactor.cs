using UnityEngine;

[RequireComponent(typeof(Health), typeof(AnimationChanger))]
public class HealthChangingReactor : MonoBehaviour
{
    private Health _health;
    private AnimationChanger _animationChanger;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _animationChanger = GetComponent<AnimationChanger>();
    }

    private void OnEnable()
    {
        _health.HealthDecreased += OnHealthDecreased;
        _health.HealthOver += OnHealthOver;
    }

    private void OnDisable()
    {
        _health.HealthDecreased -= OnHealthDecreased;
        _health.HealthOver -= OnHealthOver;
    }

    private void OnHealthDecreased(int healthValue)
    {
        if (healthValue > 0)
            _animationChanger.ActivateHurtTrigger();
    }

    private void OnHealthOver(bool isDied)
    {
       _animationChanger.ChangeDeathState(isDied);
    }
}