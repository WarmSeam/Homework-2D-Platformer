using System;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _reachDistance = 0.3f;

    public event Action<Transform> WaypointReached;

    private int _currentIndex;
    private int _waypointsCount;

    private void Awake()
    {
        _waypointsCount = _waypoints.Length;
        _currentIndex = 0;
    }

    private void Start()
    {
        WaypointReached?.Invoke(_waypoints[0].transform);
    }

    private void Update()
    {
        UpdatePathState();
    }

    private void UpdatePathState()
    {
        Transform currentPoint = _waypoints[_currentIndex].transform;

        float distance = Vector2.Distance(currentPoint.position, transform.position);

        if (distance < _reachDistance)
        {
            SwitchPoint();

            currentPoint = _waypoints[_currentIndex].transform;
            WaypointReached?.Invoke(currentPoint);
        }
    }

    private void SwitchPoint()
    {
        _currentIndex = ++_currentIndex % _waypointsCount;
    }
}