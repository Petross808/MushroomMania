using UnityEngine;

[RequireComponent(typeof(SelectableItem))]
public class MushroomInitializer : MonoBehaviour
{
    [SerializeField] private ItemList _possibleMushrooms;
    [SerializeField, Min(0)] private int _minRespawnTime;
    [SerializeField, Min(0)] private int _maxRespawnTime;

    private SelectableItem _selectableItem;
    private GameObject _prefabInstance;
    private int _nextRespawnTime;

    private void Awake()
    {
        _selectableItem = GetComponent<SelectableItem>();
        _selectableItem.OnPickup += OnPickup;
        Init();
    }

    private void OnDestroy()
    {
        _selectableItem.OnPickup -= OnPickup;
    }

    public void Init()
    {
        _nextRespawnTime = Random.Range(_minRespawnTime, _maxRespawnTime);
        var item = _possibleMushrooms.GetRandom();
        
        _selectableItem.ItemData = item.ItemData;
        _selectableItem.Activated = true;

        
        if(_prefabInstance != null)
            Destroy(_prefabInstance);
        
        _prefabInstance = Instantiate(item.Prefab, transform);
        
    }

    public void OnPickup()
    {
        _prefabInstance.SetActive(false);
        _nextRespawnTime = Random.Range(_minRespawnTime, _maxRespawnTime);
    }

    public void Tick()
    {
        _nextRespawnTime--;
        if (_nextRespawnTime == 0)
        {
            if(_prefabInstance.activeSelf)
            {
                _prefabInstance.SetActive(false);
                _nextRespawnTime = 5;
            }
            else
            {
                Init();
            }
        }
    }
}
