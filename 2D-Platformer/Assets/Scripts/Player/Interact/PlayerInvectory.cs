using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvectory : MonoBehaviour
{
    public static PlayerInvectory Instance{ get; private set; }

    private Dictionary<int, Item> itemDictionary;

    private void Awake()
    {
        if (Instance != this)
            Instance = this;
        itemDictionary = new Dictionary<int, Item>();
    }

    public void AddItem(Item _item)
    {
        itemDictionary.Add(_item.ID, _item);
    }

    public bool CheckItemContains(int _itemID)
    {
        return itemDictionary.ContainsKey(_itemID);
    }
}
