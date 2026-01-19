using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(BoxCollider2D), typeof(Rotator))]

public class EnemyStateRegulator : MonoBehaviour
{
    [SerializeField] private WaypointNavigator _waypointNavigator;

    private EnemyMover _mover;
    private Rotator _rotator;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _rotator = GetComponent<Rotator>();
    }

    private void OnEnable()
    {
        if (_waypointNavigator != null)
        {
            _waypointNavigator.WaypointReached += _mover.TakeTarget;
            _waypointNavigator.WaypointReached += _rotator.Rotate;
        }
    }

    private void OnDisable()
    {
        if (_waypointNavigator != null)
        {
            _waypointNavigator.WaypointReached -= _mover.TakeTarget;
            _waypointNavigator.WaypointReached -= _rotator.Rotate;
        }
    }
}
