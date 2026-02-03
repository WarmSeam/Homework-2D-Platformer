using UnityEngine;

[RequireComponent(typeof(HealthHandler), typeof(Animator))]

public class EnemyHealthReactor : MonoBehaviour
{
    private HealthHandler _healthHandler;
    private PlayerAnimationChanger _animationChanger;

    private void Awake()
    {
        _healthHandler = GetComponent<HealthHandler>();
        _animationChanger = GetComponent<PlayerAnimationChanger>();
    }

    private void OnEnable()
    {
        _healthHandler.HealthDecreased += OnHealthDecreased;
        _healthHandler.HealthOver += OnHealthOver;
    }

    private void OnDisable()
    {
        _healthHandler.HealthDecreased -= OnHealthDecreased;
        _healthHandler.HealthOver -= OnHealthOver;
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