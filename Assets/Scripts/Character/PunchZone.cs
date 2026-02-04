using UnityEngine;

public class PunchZone : MonoBehaviour
{
    [SerializeField] private float _radius = 1f;
    public float Radius => _radius;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}