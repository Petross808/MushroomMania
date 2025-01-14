using Items;
using System;
using System.Collections.Generic;
using Types;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "Data/ItemList")]
public class ItemList : ScriptableGameObject
{
    [SerializeField] private List<ItemDataPrefab> _itemList;

    public IReadOnlyList<ItemDataPrefab> List => _itemList;

    public ItemDataPrefab GetRandom()
    {
        if (_itemList.Count == 0)
            throw new System.Exception("Cannot get randomn item from list - Item list is empty");

        int index = UnityEngine.Random.Range(0, _itemList.Count);
        return _itemList[index];
    }

    public ItemDataPrefab GetRandom(int maxIndex)
    {
        if (_itemList.Count == 0)
            throw new System.Exception("Cannot get randomn item from list - Item list is empty");

        int index = UnityEngine.Random.Range(0, Mathf.Min(_itemList.Count, maxIndex+1));
        return _itemList[index];
    }


    [Serializable]
    public struct ItemDataPrefab
    {
        public ItemData ItemData;
        public GameObject Prefab;
    }
}
