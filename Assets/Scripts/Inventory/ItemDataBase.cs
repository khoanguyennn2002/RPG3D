using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New GroundItem Database", menuName = "Inventory System/GetSlots/Database")]
public class ItemDataBase : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemData[] ItemObjects;

    [ContextMenu("Update ID")]  
    public void UpdateID()
    {
        for (int i = 0; i < ItemObjects.Length; i++)
        {
            if (ItemObjects[i].data.Id != i)
                ItemObjects[i].data.Id = i;
        }
    }
    public void OnAfterDeserialize()
    {
        UpdateID();
    }

    public void OnBeforeSerialize()
    {

    }
}
