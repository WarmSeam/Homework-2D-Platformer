using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCarrier : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 25;
    
    public void DealDamage(HealthHandler opponent)
    {
        opponent.TakeDamage(_damageAmount);
    }
}