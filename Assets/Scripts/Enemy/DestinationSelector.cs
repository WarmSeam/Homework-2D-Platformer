using System;
using UnityEngine;

public class DestinationSelector : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _waypointReachDistance = 0.3f;
    [SerializeField] private float _playerReachDistance = 1f;
    [SerializeField] private PlayerFinder _finder;

    private int _currentIndex;
    private int _waypointsCount;

    private Vector3 _currentTarget;
    private bool _isChasingPlayer;
    private bool _isPlayerClose;

    public event Action<Vector3> WaypointChanged;
    public event Action<bool> PlayerClose;

    private void Awake()
    {
        _waypointsCount = _waypoints.Length;
        _currentIndex = 0;
        
        _isChasingPlayer = false;
        _isPlayerClose = false;
    }

    private void OnEnable()
    {
        if (_finder != null)
        {
            _finder.PlayerFound += OnPlayerFound;
            _finder.PlayerLost += OnPlayerLost;
        }
    }

    private void OnDisable()
    {
        if (_finder != null)
        {
            _finder.PlayerFound -= OnPlayerFound;
            _finder.PlayerLost -= OnPlayerLost;
        }
    }

    private void Start()
    {
        if (_waypointsCount > 0)
            WaypointChanged?.Invoke(_waypoints[0].transform.position);
    }

    private void Update()
    {
        UpdatePathState();
    }

    private void UpdatePathState()
    {
        if (_isChasingPlayer == false)
        {
            _currentTarget = _waypoints[_currentIndex].transform.position;

            if (transform.position.IsEnoughClose(_currentTarget, _waypointReachDistance))
            {
                SwitchPoint();

                _currentTarget = _waypoints[_currentIndex].transform.position;
                WaypointChanged?.Invoke(_currentTarget);
            }
        }
        else
        {
            if (transform.position.IsEnoughClose(_currentTarget, _playerReachDistance))
            {
                _isPlayerClose = true;
                PlayerClose?.Invoke(_isPlayerClose);
            }
        }
    }

    private void SwitchPoint()
    {
        if (_waypointsCount > 0)
            _currentIndex = ++_currentIndex % _waypointsCount;
    }

    private void OnPlayerFound(Vector3 playerPosition)
    {
        _isChasingPlayer = true;
        _currentTarget = playerPosition;
        WaypointChanged?.Invoke(_currentTarget);
    }

    private void OnPlayerLost()
    {
        _isChasingPlayer = false;
        _currentTarget = _waypoints[_currentIndex].transform.position;
        WaypointChanged?.Invoke(_currentTarget);
    }
}