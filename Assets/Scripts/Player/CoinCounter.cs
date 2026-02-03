using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private ItemCollector _collector;

    private int _count;

    private void Awake()
    {
        _count = 0;
    }

    private void OnEnable()
    {
        if(_collector != null) 
        _collector.CoinCollected += IncreaseCount;
    }

    private void OnDisable()
    {
        if (_collector != null)
            _collector.CoinCollected -= IncreaseCount;
    }

    private void IncreaseCount(Coin coin)
    {
        _count += 1;
        Debug.Log("Coins: " + _count);
    }
}
