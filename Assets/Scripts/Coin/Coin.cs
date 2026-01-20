using UnityEngine;

public class Coin : MonoBehaviour
{
    public SpawnPoint CurrentSpawnPoint {  get; private set; }

    public void SetSpawnPoint(SpawnPoint point)
    {
        CurrentSpawnPoint = point;
    }
}
