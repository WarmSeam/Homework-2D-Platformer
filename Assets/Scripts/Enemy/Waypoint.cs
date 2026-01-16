using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }

    private void Start()
    {
        transform.SetParent(null);
    }
}
