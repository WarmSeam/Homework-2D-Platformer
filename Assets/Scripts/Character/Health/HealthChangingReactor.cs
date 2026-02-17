using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthChangingReactor : MonoBehaviour
{
    [SerializeField] private AnimationChanger _animationChanger;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Decreased += OnHealthDecreased;
        _health.Over += OnHealthOver;
    }

    private void OnDisable()
    {
        _health.Decreased -= OnHealthDecreased;
        _health.Over -= OnHealthOver;
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