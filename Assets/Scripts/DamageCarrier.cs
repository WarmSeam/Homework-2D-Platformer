using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]

public class DamageCarrier : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 25;

    private CircleCollider2D _circleCollider;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _circleCollider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HitDetector opponent))
            opponent.HandleHitTaking(_damageAmount);
    }
}