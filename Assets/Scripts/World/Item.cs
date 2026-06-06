using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item")]
public class Item : ScriptableObject
{
    public int ID;
    public Sprite sprite;
    public string Name;
    public int quantity;
    public enum Type
    {
        Item,
        Weapon,
        Armor
    }
    [SerializeField] public Type type;

    public void AddItem(int amount)
    {
        quantity += amount;
    }

    public virtual void Use()
    {
        quantity--;
    }

    public void Set(Item baseItem)
    {
        sprite = baseItem.sprite;
        Name = baseItem.Name;
        quantity = baseItem.quantity;
        type = baseItem.type;
    }
}
