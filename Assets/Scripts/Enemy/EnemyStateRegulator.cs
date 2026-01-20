using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(BoxCollider2D), typeof(Rotator))]

public class EnemyStateRegulator : MonoBehaviour
{
    [SerializeField] private DestinationSelector _destinationSelector;

    private EnemyMover _mover;
    private Rotator _rotator;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _rotator = GetComponent<Rotator>();
    }

    private void OnEnable()
    {
        if (_destinationSelector != null)
        {
            _destinationSelector.WaypointReached += _mover.TakeTarget;
            _destinationSelector.WaypointReached += _rotator.Rotate;
        }
    }

    private void OnDisable()
    {
        if (_destinationSelector != null)
        {
            _destinationSelector.WaypointReached -= _mover.TakeTarget;
            _destinationSelector.WaypointReached -= _rotator.Rotate;
        }
    }
}
