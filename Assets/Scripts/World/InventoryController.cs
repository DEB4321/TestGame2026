using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject noItems;
    public List<Item> items;
    public List<GameObject> itemPrefabs = new List<GameObject>();
    public GameObject itemPrefab;
    private int itemNo = 0;
    private bool entered = false;
    private ItemDictionary itemDictionary;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemDictionary = FindAnyObjectByType<ItemDictionary>();
        
        //if (items.Count > 0)
        //{
        //    noItems.SetActive(false);

        //    for (int i = 0; i < items.Count; i++)
        //    {
        //        GameObject item = Instantiate(itemPrefab, inventoryPanel.transform);
        //        ItemToPrefab(item, items[i]);
        //    }
        //}
    }

    public void Activate(int itemNo)
    {
        for (int i = 0; i < itemPrefabs.Count; i++)
        {
            ChangePrefabColor(i, Color.gray, Color.black);
        }

        ChangePrefabColor(itemNo, Color.white, Color.black);
    }

    public void Enter()
    {
        if (!entered && items.Count > 0)
        {
            entered = true;
            Activate(0);
            itemNo = 0;
        }
    }

    public void Exit()
    {
        if (entered)
        {
            entered = false;

            for (int i = 0; i < itemPrefabs.Count; i++)
            {
                ChangePrefabColor(i, Color.white, Color.black);
            }
        }
    }

    public void ChangePrefabColor(int itemNo, Color imageColor, Color textColor)
    {
        Image[] images = itemPrefabs[itemNo].GetComponentsInChildren<Image>();
        images[0].color = imageColor;
        images[1].color = imageColor;
        TextMeshProUGUI[] texts = itemPrefabs[itemNo].GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].color = textColor;
        texts[1].color = textColor;
    }

    public void AddItem(Item newItem)
    {
        if (items.Count == 0) noItems.SetActive(false);

        foreach(Item compareItem in items)
        {
            if(newItem.Name == compareItem.Name)
            {
                compareItem.AddItem(newItem.quantity);
                UpdatePrefabQuantity();
                return;
            }
        }

        Item dictItem = itemDictionary.GetItem(newItem.Name);
        dictItem.quantity = newItem.quantity;
        items.Add(dictItem);

        GameObject item = Instantiate(itemPrefab, inventoryPanel.transform);
        ItemToPrefab(item, newItem);
    }

    private void ItemToPrefab(GameObject itemPrefab, Item newItem)
    {
        itemPrefab.GetComponentsInChildren<Image>()[1].sprite = newItem.sprite;
        TextMeshProUGUI[] names = itemPrefab.GetComponentsInChildren<TextMeshProUGUI>();
        names[0].text = newItem.Name;
        names[1].text = newItem.quantity.ToString();
        itemPrefabs.Add(itemPrefab);
    }

    public void ItemControl(InputAction.CallbackContext context)
    {
        if(entered && context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();

            //Item right
            if (input.x > 0 && itemNo + 1 < items.Count && itemNo % 3 < 2)
            {
                itemNo++;
                Activate(itemNo);
            }

            //Item left
            if (input.x < 0 && itemNo - 1 >= 0 && itemNo % 3 > 0)
            {
                itemNo--;
                Activate(itemNo);
            }
            
            //Item up
            if (input.y > 0 && itemNo - 3 >= 0)
            {
                itemNo -= 3;
                Activate(itemNo);
            }

            //Item down
            if (input.y < 0 && itemNo + 3 < items.Count)
            {
                itemNo += 3;
                Activate(itemNo);
            }
        }
    }

    public void UseItem(InputAction.CallbackContext context)
    {
        if (context.started && entered)
        {
            items[itemNo].Use();
            UpdatePrefabQuantity();
        }
    }

    private void UpdatePrefabQuantity()
    {
        if (items[itemNo].quantity <= 0)
        {
            items.RemoveAt(itemNo);
            Destroy(itemPrefabs[itemNo]);
            itemPrefabs.RemoveAt(itemNo);
            if (items.Count <= 0)
            {
                noItems.SetActive(true);
            }
            return;
        }
        TextMeshProUGUI[] names = itemPrefabs[itemNo].GetComponentsInChildren<TextMeshProUGUI>();
        names[1].text = items[itemNo].quantity.ToString();
    }
    
    public List<ItemSaveData> GetInventoryItems()
    {
        List<ItemSaveData> itemData = new List<ItemSaveData>();

        foreach(Item item in items)
        {
            print("saved item");
            itemData.Add(new ItemSaveData { savedItem = item, quantity = item.quantity });
        }

        return itemData;
    }
    
    public void SetInventoryItems(List<ItemSaveData> itemsInv)
    {
        foreach(Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        items.Clear();
        itemPrefabs.Clear();

        foreach(ItemSaveData data in itemsInv)
        {
            data.savedItem.quantity = data.quantity;
            items.Add(data.savedItem);
           
        }

        if (items.Count > 0)
        {
            noItems.SetActive(false);

            foreach(Item item in items)
            {
                GameObject newItem = Instantiate(itemPrefab, inventoryPanel.transform);
                ItemToPrefab(newItem, item);
            }
        }
    }
}
