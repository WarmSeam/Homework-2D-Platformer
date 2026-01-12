using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private Enemy _enemyParent;
    private Vector3 _globalPosition;

    private void Awake()
    {
        _enemyParent = GetComponentInParent<Enemy>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }

    private void Start()
    {
        AdjustPosition();
        _globalPosition = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = _globalPosition;
    }
    private void AdjustPosition()
    {
        if (_enemyParent != null)
            transform.position = new Vector3(transform.position.x, _enemyParent.transform.position.y, transform.position.z);
    }
}
