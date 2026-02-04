using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(Health), typeof(Attacker))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private PlayerMover _movement;
    private Rotator _rotator;
    private Attacker _attacker;
    private Health _health;

    private void Awake()
    {
        _movement = GetComponent<PlayerMover>();
        _rotator = GetComponent<Rotator>();
        _attacker = GetComponent<Attacker>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _inputReader.InputChanged += SetRotation;
        _inputReader.InputChanged += _movement.Move;
        _inputReader.RunPressed += _movement.Run;
        _inputReader.JumpRequested += _movement.Jump;
        _inputReader.AttackPressed += _attacker.BeginAttack;

        _health.HealthOver += Die;
    }

    private void OnDisable()
    {
        _inputReader.InputChanged -= SetRotation;
        _inputReader.InputChanged -= _movement.Move;
        _inputReader.RunPressed -= _movement.Run;
        _inputReader.JumpRequested -= _movement.Jump;

        _health.HealthOver -= Die;
    }

    private void SetRotation(float direction)
    {
        Vector3 targetDirection = new Vector3(direction, 0, 0) + transform.position;
        _rotator.Rotate(targetDirection);
    }

    private void Die(bool isDied)
    {
        if (isDied)
        {
            _inputReader.enabled = false;
            _movement.enabled = false;
            _rotator.enabled = false;
            _attacker.enabled = false;

            if (TryGetComponent(out Rigidbody2D rigidbody))
                rigidbody.bodyType = RigidbodyType2D.Static;

            if (TryGetComponent(out Collider2D collider))
                collider.enabled = false;
        }
    }
}
