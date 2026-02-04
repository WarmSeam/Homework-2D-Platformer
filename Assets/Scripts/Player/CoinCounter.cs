using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private ItemCollector _itemCollector;

    private int _count;

    private void Awake()
    {
        _count = 0;
    }

    private void OnEnable()
    {
        if(_itemCollector != null) 
        _itemCollector.CoinCollected += OnCoinCollected;
    }

    private void OnDisable()
    {
        if (_itemCollector != null)
            _itemCollector.CoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected()
    {
        _count += 1;
        Debug.Log("Coins: " + _count);
    }
}
