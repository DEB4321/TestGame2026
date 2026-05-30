using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject noItems;
    public Item[] items;
    public GameObject itemPrefab;
    public List<GameObject> itemPrefabs = new List<GameObject>();
    private int itemNo = 0;
    private bool entered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (items.Length > 0)
        {
            noItems.SetActive(false);

            for (int i = 0; i < items.Length; i++)
            {
                GameObject item = Instantiate(itemPrefab, inventoryPanel.transform);
                item.GetComponentsInChildren<Image>()[1].sprite = items[i].sprite;
                TextMeshProUGUI[] names = item.GetComponentsInChildren<TextMeshProUGUI>();
                names[0].text = items[i].Name;
                names[1].text = items[i].quantity.ToString();
                itemPrefabs.Add(item);
            }
        }
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
        if (!entered)
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
}
