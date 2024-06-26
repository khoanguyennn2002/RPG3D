using UnityEngine;


public class ItemData : ScriptableObject
{
    public Sprite image;
    public bool stackable;
    public GameObject prefab;
    public ItemType itemType;
    [TextArea(5,5)]
    public string description;
    public Item data = new Item();
    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id = -1;
    public ItemBuff[] buffs;

    public Item()
    {
        Name = "";
        Id = -1;
    }
    public Item(ItemData item)
    {
        Name = item.name;
        Id = item.data.Id;
        buffs = new ItemBuff[item.data.buffs.Length];

        for(int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff();
            buffs[i].value = item.data.buffs[i].value;
            buffs[i].attribute = item.data.buffs[i].attribute;
        }
    }
}
[System.Serializable]
public class ItemBuff
{
    public Attributes attribute;
    public int value;
}

