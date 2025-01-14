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

    private int _currentLevel = 0;

    [SerializeField] private IntGameEvent _levelUpEvent;

    public void Reset()
    {
        _right.ResetValue();
        _wrong.ResetValue();
        _currentLevel = 0;
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

    public void OnAchievement()
    {
        _levelUpEvent?.Raise(_currentLevel);
        _currentLevel++;
    }
}
