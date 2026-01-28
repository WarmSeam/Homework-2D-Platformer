using UnityEngine;

public class DamageCarrier : MonoBehaviour
{
    private readonly int Attack = Animator.StringToHash(nameof(Attack));

    [SerializeField] private int _damageAmount = 25;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HitDetector opponent))
            opponent.TakeDamage(_damageAmount);
    }
}