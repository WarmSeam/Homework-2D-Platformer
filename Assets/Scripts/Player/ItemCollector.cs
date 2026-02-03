using System;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public event Action<Coin> CoinCollected;
    public event Action<Heal> HealPickedUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
            CoinCollected?.Invoke(coin);

        if(collision.TryGetComponent(out Heal heal))
            HealPickedUp?.Invoke(heal);
    }
}
