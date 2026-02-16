using System;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int _healValue = 30;

    public event Action<Heal> HealPicked;

    public int Value => _healValue;

    public void PickedUp()
    {
        HealPicked?.Invoke(this);
    }
}
