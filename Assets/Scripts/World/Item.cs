using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item")]
public class Item : ScriptableObject
{
    public Sprite icon;
    public string Name;
    public int quantity;
    
    public void AddItem(int amount)
    {
        quantity += amount;
    }
}
