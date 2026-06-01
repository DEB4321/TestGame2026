using System.Collections.Generic;
using UnityEngine;

public class ItemDictionary : MonoBehaviour
{
    public List<Item> items;
    private Dictionary<int, Item> itemDictionary;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        itemDictionary = new Dictionary<int, Item>();

        for(int i=0; i<items.Count; i++)
        {
            if (items[i] != null)
            {
                items[i].ID = i + 1;
            }
        }

        foreach(Item item in items)
        {
            itemDictionary[item.ID] = item;
        }
    }

    public Item GetItem(int itemID)
    {
        itemDictionary.TryGetValue(itemID, out Item item);
        if(item == null)
        {
            Debug.LogWarning($"Sprite with ID {itemID} not found in dictionary");
        }

        return item;
    }
}