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
    [SerializeField] private Type type;

    public void AddItem(int amount)
    {
        quantity += amount;
    }

    public virtual void Use()
    {
        quantity--;
    }
}
