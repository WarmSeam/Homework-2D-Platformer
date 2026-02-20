using System;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public event Action CoinCollected;
    public event Action<int> HealCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.Collect();
            CoinCollected?.Invoke();
        }

        if (collision.TryGetComponent(out Heal heal))
        {
            heal.PickedUp();
            HealCollected?.Invoke(heal.Value);
        }
    }
}
