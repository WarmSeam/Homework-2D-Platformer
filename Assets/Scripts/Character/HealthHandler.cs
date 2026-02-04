using UnityEngine;

[RequireComponent(typeof(Health), typeof(HitDetector), typeof(HealthChangingReactor))]
public class HealthHandler : MonoBehaviour
{
    [SerializeField] private ItemCollector _itemCollector;

    private Health _health;
    private HitDetector _hitDetector;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _hitDetector = GetComponent<HitDetector>();
    }
    private void OnEnable()
    {
        _hitDetector.HitTaken += OnHitTaken;

        if (_itemCollector != null)
            _itemCollector.HealCollected += OnHealPickedUp;
    }

    private void OnDisable()
    {
        _hitDetector.HitTaken -= OnHitTaken;

        if (_itemCollector != null)
            _itemCollector.HealCollected -= OnHealPickedUp;
    }

    private void OnHitTaken(int damage)
    {
        _health.Decrease(damage);
    }

    private void OnHealPickedUp(Heal heal)
    {
        _health.Increase(heal.Value);
    }
}

