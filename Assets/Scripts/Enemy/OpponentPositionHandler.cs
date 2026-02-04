using UnityEngine;

[RequireComponent (typeof(EnemyMover))]
public class OpponentPositionHandler : MonoBehaviour
{
    [SerializeField] private PlayerFinder _playerFinder;

    private EnemyMover _mover;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    private void OnEnable()
    {
        _playerFinder.PlayerFound += OnPlayerFound;
        _playerFinder.PlayerLost += OnPlayerLost;
    }

    private void OnPlayerFound(Vector3 target)
    {
        _mover.SpeedUp(target);
    }

    private void OnPlayerLost()
    {
        _mover.SlowDown();
    }
}
