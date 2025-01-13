using EventSystem;
using Items;
using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SelectableItem : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private ItemDataGameEvent _itemPickupEvent;

    private bool _activated;

    public ItemData ItemData {  get { return _itemData; } set { _itemData = value; } }
    public bool Activated { get { return _activated; } set { _activated = value; } }

    public event Action OnPickup;

    private void OnSelectItem()
    {
        if(_activated)
        {
            _itemPickupEvent?.Raise(_itemData);
            OnPickup?.Invoke();
            _activated = false;
        }
    }

    private void OnDeselectItem()
    {

    }

    public void Select(Transform selected)
    {
        if (transform != selected)
            return;
        OnSelectItem();
    }

    public void Deselect(Transform deselected)
    {
        if (transform != deselected)
            return;
        OnDeselectItem();
    }
}
