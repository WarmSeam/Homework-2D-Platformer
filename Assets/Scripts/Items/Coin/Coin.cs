using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> CoinCollected;

    public SpawnPoint CurrentSpawnPoint {  get; private set; }

    public void SetSpawnPoint(SpawnPoint point)
    {
        CurrentSpawnPoint = point;
    }

    public void Collect()
    {
        CoinCollected?.Invoke(this);
    }
}
