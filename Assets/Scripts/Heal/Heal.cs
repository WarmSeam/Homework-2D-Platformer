using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int _healValue = 30;

    public int Value => _healValue;
}
