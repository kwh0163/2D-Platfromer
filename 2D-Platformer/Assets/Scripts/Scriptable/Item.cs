using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable/CreateItem")]
public class Item : ScriptableObject
{
    [SerializeField] private int itemID;
    [SerializeField] private string itemName;
    
    public int ID { get { return itemID; } }
    public string Name { get { return itemName; } }
}
