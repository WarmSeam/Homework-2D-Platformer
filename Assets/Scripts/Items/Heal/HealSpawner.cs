using System.Linq;
using UnityEngine;

public class HealSpawner : MonoBehaviour
{
    [SerializeField] private Heal _healPrefab;
    [SerializeField] private HealSpawnPoint[] _points;

    private int _healsCount;
    private int _objectsToPointsRatio = 2;

    private void Awake()
    {
        _healsCount = _points.Length / _objectsToPointsRatio;
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        HealSpawnPoint[] randomPoints = _points.OrderBy(_ => Random.value).Take(_healsCount).ToArray();

        foreach (var point in randomPoints)
        {
           Heal heal = Instantiate(_healPrefab, point.transform.position, Quaternion.identity, transform);
            heal.HealPicked += DestroyHeal;
        }    
    }

    private void DestroyHeal(Heal heal)
    {
        heal.HealPicked -= DestroyHeal;
        Destroy(heal.gameObject);
    }
}
