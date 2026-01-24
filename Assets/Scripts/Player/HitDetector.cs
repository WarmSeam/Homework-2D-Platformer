using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    public event Action HitReceived;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
