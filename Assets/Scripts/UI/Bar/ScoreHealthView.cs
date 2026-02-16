using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreHealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    protected virtual void OnEnable()
    {
        _health.Decreased += UpdateText;
        _health.Increased += UpdateText;
    }

    protected virtual void OnDisable()
    {
        _health.Decreased -= UpdateText;
        _health.Increased -= UpdateText;
    }

    private void UpdateText(int currentHealth)
    {
        _text.text = currentHealth + " / " + _health.Max;
    }

}
