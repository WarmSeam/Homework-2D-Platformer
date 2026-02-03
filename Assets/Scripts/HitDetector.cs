using System;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    public event Action<int> HitTaken;

    public void HandleHitTaking(int damage)
    {
        HitTaken?.Invoke(damage);
    }
}
