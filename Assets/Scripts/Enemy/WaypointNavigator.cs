using System;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _reachDistance = 0.3f;

    public event Action<Vector3> WaypointReached;

    private int _currentIndex;
    private int _waypointsCount;

    private void Awake()
    {
        _waypointsCount = _waypoints.Length;
        _currentIndex = 0;
    }

    private void Start()
    {
        WaypointReached?.Invoke(_waypoints[0].transform.position);
    }

    private void Update()
    {
        UpdatePathState();
    }

    private void UpdatePathState()
    {
        Vector3 currentPoint = _waypoints[_currentIndex].transform.position;

        if (transform.position.IsEnoughClose(currentPoint, _reachDistance))
        {
            SwitchPoint();

            currentPoint = _waypoints[_currentIndex].transform.position;
            WaypointReached?.Invoke(currentPoint);
        }
    }

    private void SwitchPoint()
    {
        _currentIndex = ++_currentIndex % _waypointsCount;
    }
}