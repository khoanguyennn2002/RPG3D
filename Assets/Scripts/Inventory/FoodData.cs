
using UnityEngine;
[CreateAssetMenu(fileName = "New Food Data", menuName = "Inventory System/ItemObjects/Food")]

public class FoodObject : ItemData
{
    public int restoreHealthValue;
    public void Awake()
    {
        itemType = ItemType.Food;
    }
}
