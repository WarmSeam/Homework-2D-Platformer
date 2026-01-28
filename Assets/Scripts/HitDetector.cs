using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    public event Action<int> DamageTaken;

    public void TakeDamage(int damage)
    {
        DamageTaken?.Invoke(damage);
    }
}
