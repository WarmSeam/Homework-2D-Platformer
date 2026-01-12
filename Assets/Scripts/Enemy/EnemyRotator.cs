using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    private WaypointNavigator _waypointNavigator;

    private void Awake()
    {
        _waypointNavigator = GetComponentInChildren<WaypointNavigator>();
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
        Vector3 rotation = transform.eulerAngles;

        if (target.position.x <= transform.position.x)
            rotation.y = -180;
        else
            rotation.y = 0;

        transform.eulerAngles = rotation;
    }
}
