using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";
    private const string Run = "Fire3";
    private const KeyCode HitButton = KeyCode.F;

    public event Action<float> InputChanged;
    public event Action<bool> JumpRequested;
    public event Action<bool> RunPressed;
    public event Action<bool> HitPressed;

    private void Update()
    {
        float horizontal = Input.GetAxis(Horizontal);
        bool isJumped = Input.GetButtonDown(Jump);
        bool isRunning = Input.GetButton(Run);
        bool isHitted = Input.GetKeyDown(HitButton);

        InputChanged?.Invoke(horizontal);
        JumpRequested?.Invoke(isJumped);
        RunPressed?.Invoke(isRunning);
        HitPressed?.Invoke(isHitted);
    }
}
