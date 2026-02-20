using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothBar : BarBase
{
    [SerializeField] private float _duration = 0.3f;

    private Coroutine _updateBarCortoutine;

    protected override void UpdateView(float value)
    {
        if (_updateBarCortoutine != null)
            StopCoroutine(_updateBarCortoutine);

        _updateBarCortoutine = StartCoroutine(UpdateBar(value));
    }

    private IEnumerator UpdateBar(float targetValue)
    {
        float startValue = Slider.value;
        float elapsedTime = 0f;

        while (elapsedTime < _duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / _duration;

            Slider.value = Mathf.Lerp(startValue, targetValue, progress);
            yield return null;
        }

        Slider.value = targetValue;
        _updateBarCortoutine = null;
    }
}
