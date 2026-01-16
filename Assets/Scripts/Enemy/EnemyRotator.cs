using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    private WaypointNavigator _waypointNavigator;
    private Quaternion _faceLeft;
    private Quaternion _faceRight;

    private void Awake()
    {
        _waypointNavigator = GetComponentInChildren<WaypointNavigator>();

        _faceRight = Quaternion.Euler(0, 0, 0);
        _faceLeft = Quaternion.Euler(0, 180, 0);
    }

    private void OnEnable()
    {
        _waypointNavigator.WaypointReached += Rotate;
    }

    private void OnDisable()
    {
        _waypointNavigator.WaypointReached -= Rotate;
    }

    private void Rotate(Transform target)
    {
        if (target.position.x <= transform.position.x)
            transform.rotation = _faceLeft;
        else
            transform.rotation = _faceRight;
    }
}
