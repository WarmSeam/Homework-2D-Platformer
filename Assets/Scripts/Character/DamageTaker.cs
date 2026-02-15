using System;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    public event Action<int> DamageTaken;

    public void HandleTakingDamage(int value)
    {
        DamageTaken?.Invoke(value);
    }
}
