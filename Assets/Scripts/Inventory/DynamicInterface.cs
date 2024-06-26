using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicInterface : UserInterface
{
     public GameObject SlotPrefab;
     public int X_START;
     public int Y_START;
     public int X_SPACE_ITEM;
     public int Y_SPACE_ITEM;
     public int numberColumn;
    public override void CreateSlots()
    {
        slotOnInterface = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.GetSlots.Length; i++)
        {
            var obj = Instantiate(SlotPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.localPosition = GetPosition(i);

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnBeginDrag(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnEndDrag(obj); });
            inventory.GetSlots[i].slotDisplay = obj;

            slotOnInterface.Add(obj, inventory.GetSlots[i]);
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_ITEM * (i % numberColumn)), Y_START + (-Y_SPACE_ITEM * (i / numberColumn)), 0f);
    }
}
