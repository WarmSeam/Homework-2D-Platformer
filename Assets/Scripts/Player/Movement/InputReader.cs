using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";
    private const string Run = "Fire3";
    private const KeyCode AttackButton = KeyCode.F;

    public event Action<float> InputChanged;
    public event Action<bool> JumpRequested;
    public event Action<bool> RunPressed;
    public event Action<bool> AttackPressed;

    private void Update()
    {
        float horizontal = Input.GetAxis(Horizontal);
        bool isJumped = Input.GetButtonDown(Jump);
        bool isRunning = Input.GetButton(Run);
        bool isHitted = Input.GetKeyDown(AttackButton);

        InputChanged?.Invoke(horizontal);
        JumpRequested?.Invoke(isJumped);
        RunPressed?.Invoke(isRunning);
        AttackPressed?.Invoke(isHitted);
    }
}
