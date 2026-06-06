using System.Collections.Generic;
using UnityEngine;

public class ItemDictionary : MonoBehaviour
{
    public List<Item> items;
    private Dictionary<string, Item> itemDictionary;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        itemDictionary = new Dictionary<string, Item>();

        foreach(Item item in items)
        {
            itemDictionary[item.Name] = item;
        }
    }

    public Item GetItem(string name)
    {
        itemDictionary.TryGetValue(name, out Item item);
        if(item == null)
        {
            Debug.LogWarning($"Sprite with name {name} not found in dictionary");
        }

        return item;
    }
}