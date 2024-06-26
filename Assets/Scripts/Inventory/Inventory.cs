using System;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    public ItemDataBase dataBase { get; private set; }
    public InventorySlot[] Slots = new InventorySlot[30];
    public InventorySlot[] GetSlots { get { return Slots; } }
    public InterfaceType type; 
    [ContextMenu("Clear")]
    public void Clear()
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            GetSlots[i].RemoveItem();
        }
    }

    private void OnEnable()
    {
        dataBase = Resources.Load<ItemDataBase>("Database");

    }
    public bool AddItem(Item _item, int _amount)
    {
        if (EmptySlotCount <= 0)
        {
            return false;
        }
        InventorySlot slot = FindItemOnInventory(_item);
        if (!dataBase.ItemObjects[_item.Id].stackable || slot == null)
        {
            SetEmptySlot(_item,_amount);
            return true;
        }
        slot.AddAmount(_amount);
        return true;
    }
    public int EmptySlotCount
    {
        get
        {
            int counter = 0;
            for(int i = 0; i < GetSlots.Length; i++)
            {
                if(GetSlots[i].item.Id <= -1 )
                {
                    counter++;
                }
            }
            return counter;
        }
    }
    public InventorySlot FindItemOnInventory(Item _item)
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if (GetSlots[i].item.Id == _item.Id)
            {
                return GetSlots[i];
            }
        }
        return null;
    }
    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        for(int i =0; i < GetSlots.Length; i++)
        {
          if(GetSlots[i].item.Id <= -1)
            {
                GetSlots[i].UpdateSlot(_item, _amount);
                return GetSlots[i];
            }
        }
        return null;
    }
    public void SwapItems(InventorySlot item1, InventorySlot item2)
    {
        if(item2.CanPlaceInSlot(item1.itemData) && item1.CanPlaceInSlot(item2.itemData))
        {
        InventorySlot temp = new InventorySlot(item2.item, item2.amount);
        item2.UpdateSlot(item1.item, item1.amount);
        item1.UpdateSlot(temp.item, temp.amount);
        }
    }
    public void RemoveItem(Item item)
    {
        for(int i = 0;i< GetSlots.Length;i++)
        {
            if (GetSlots[i].item == item)
            {
                GetSlots[i].UpdateSlot(null, 0);
            }
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public Action<InventorySlot> OnAfterUpdate;
    public Action<InventorySlot> OnBeforeUpdate;
    public ItemType[] itemType = new ItemType[0];
    [System.NonSerialized]
    public UserInterface parent;
    [System.NonSerialized]
    public GameObject slotDisplay;
    public Item item;
    public int amount;

    public ItemData itemData { 
        get 
        { 
            if(item.Id >= 0)
            {
                return parent.inventory.dataBase.ItemObjects[item.Id];
            }
            return null;
        } 
    }

    public void RemoveItem()
    {
        UpdateSlot(new Item(), 0);
    }
    public InventorySlot()
    {
        UpdateSlot(new Item(),0 );
    }
    public InventorySlot( Item _item, int _amount)
    {
        UpdateSlot(_item, _amount);
    }
    public void UpdateSlot( Item _item, int _amount)
    {
        if(OnBeforeUpdate !=null)
        {
            OnBeforeUpdate.Invoke(this);
        }
        item = _item;
        amount = _amount;
        if(OnAfterUpdate !=null)
        {
            OnAfterUpdate.Invoke(this);
        }
    }
    public void AddAmount(int value)
    {
        UpdateSlot(item, amount += value) ;
    }
    public bool CanPlaceInSlot(ItemData item)
    {
        
        if (itemType.Length <= 0 || item == null || item.data.Id < 0 )
        {
            return true;
        }
        
        if(item.itemType == itemType[0])
        {
            return true;
        }
        return false;
    }
}
