using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(HealthHandler), typeof(Rotator))]

public class EnemyStateRegulator : MonoBehaviour
{
    [SerializeField] private DestinationSelector _destinationSelector;

    private EnemyMover _mover;
    private Rotator _rotator;
    private HealthHandler _healthHandler;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _rotator = GetComponent<Rotator>();
        _healthHandler = GetComponent<HealthHandler>();
    }

    private void OnEnable()
    {
        if (_destinationSelector != null)
        {
            _destinationSelector.WaypointChanged += _mover.SetTarget;
            _destinationSelector.WaypointChanged += _rotator.Rotate;
        }

        _healthHandler.HealthOver += Die;
    }

    private void OnDisable()
    {
        if (_destinationSelector != null)
        {
            _destinationSelector.WaypointChanged -= _mover.SetTarget;
            _destinationSelector.WaypointChanged -= _rotator.Rotate;
        }

        _healthHandler.HealthOver -= Die;
    }

    private void Die(bool isDied)
    {
        if (isDied)
        {
            _mover.enabled = false;
            _rotator.enabled = false;
            _destinationSelector.enabled = false;

            if (TryGetComponent(out Rigidbody2D rigidbody))
                rigidbody.bodyType = RigidbodyType2D.Static;

            if (TryGetComponent(out Collider2D collider))
                collider.enabled = false;
        }
    }
}
