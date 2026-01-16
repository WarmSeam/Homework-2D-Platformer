using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public event Action CoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.Collect();
            CoinCollected?.Invoke();
        }
    }
}
