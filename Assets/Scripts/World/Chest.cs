using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public bool isOpened { get; private set; }
    public string ChestID { get; private set; }
    public Item item;
    public Sprite openedSprite;
    private InventoryController inventoryController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChestID ??= GlobalHelper.GenerateUniqueID(gameObject);
        inventoryController = FindAnyObjectByType<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanInteract()
    {
        return !isOpened;
    }

    public void Interact()
    {
        if (!CanInteract()) return;
        OpenChest();
    }

    private void OpenChest()
    {
        SetOpened(true);

        if (item)
        {
            inventoryController.AddItem(item);
        }
    }

    public void SetOpened(bool opened)
    {
        if (isOpened = opened)
        {
            GetComponent<SpriteRenderer>().sprite = openedSprite;
        }
    }
}
