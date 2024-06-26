using UnityEngine;

[CreateAssetMenu(fileName = "New Default Data", menuName = "Inventory System/ItemObjects/Default")]

public class DefaultItem : ItemData
{
    public void Awake()
    {
        itemType = ItemType.Default;
    }
}
