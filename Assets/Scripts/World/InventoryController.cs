using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject noItems;
    public Item[] items;
    public GameObject itemPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (items.Length > 0)
        {
            noItems.SetActive(false);
            
            for (int i = 0; i < items.Length; i++)
            {
                GameObject item = Instantiate(itemPrefab, inventoryPanel.transform);
                item.GetComponentsInChildren<Image>()[1].sprite = items[i].icon;
                TextMeshProUGUI[] names = item.GetComponentsInChildren<TextMeshProUGUI>();
                names[0].text = items[i].Name;
                names[1].text = items[i].quantity.ToString();
            }
        }
    }

    
}
