using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";
    private const string Run = "Fire3";

    public event Action<float> InputChanged;
    public event Action<bool> JumpRequested;
    public event Action<bool> RunPressed;

    private void Update()
    {
        float horizontal = Input.GetAxis(Horizontal);
        bool isJumped = Input.GetButtonDown(Jump);
        bool isRunning = Input.GetButton(Run);

        InputChanged?.Invoke(horizontal);
        JumpRequested?.Invoke(isJumped);
        RunPressed?.Invoke(isRunning);
    }
}
