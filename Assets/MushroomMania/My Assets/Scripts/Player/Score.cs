using EventSystem;
using Items;
using System.Collections;
using System.Collections.Generic;
using TypesAdvanced;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private IntVariable _right;
    [SerializeField] private IntVariable _wrong;

    [SerializeField] private Inventory _mushroomInventory;

    public void Reset()
    {
        _right.ResetValue();
        _wrong.ResetValue();
    }

    public void UpdateScore()
    {
        int right = 0;
        int wrong = 0;
        foreach(var item in _mushroomInventory)
        {
            switch (item.Item.ItemType)
            {
                case ItemType.Edible:
                    right += item.Amount;
                    break;
                case ItemType.Poisonous:
                    wrong += item.Amount;
                    break;
                default:
                    break;
            }
        }
        _right.Value = right;
        _wrong.Value = wrong;
    }
}
