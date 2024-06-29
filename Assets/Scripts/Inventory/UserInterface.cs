using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UserInterface : MonoBehaviour
{
    public Inventory inventory;
 
    public Dictionary<GameObject, InventorySlot> slotOnInterface = new Dictionary<GameObject, InventorySlot>();

    private void Awake()
    {
        for (int i = 0; i < inventory.GetSlots.Length; i++)
        {
            inventory.GetSlots[i].parent = this;
            inventory.GetSlots[i].OnAfterUpdate += OnSlotUpdate;
        }

        CreateSlots();

        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate { OnEnterInterface(gameObject); });
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate { OnExitInterface(gameObject); });

        
    }

    private void OnDestroy()
    {
        for (int i = 0; i < inventory.GetSlots.Length; i++)
        {
            inventory.GetSlots[i].OnAfterUpdate -= OnSlotUpdate;
        }
    }
    private void OnSlotUpdate(InventorySlot _slot)
    {
        if (_slot.item.Id >= 0)
        {
            _slot.slotDisplay.transform.GetChild(0).GetChild(0).GetComponentInChildren<Image>().sprite = _slot.itemData.image;
            _slot.slotDisplay.transform.GetChild(0).GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
            _slot.slotDisplay.transform.GetComponentInChildren<TextMeshProUGUI>().text = _slot.amount == 1 ? "" : _slot.amount.ToString("n0");
        }
        else
        {

            _slot.slotDisplay.transform.GetChild(0).GetChild(0).GetComponentInChildren<Image>().sprite = null;
            _slot.slotDisplay.transform.GetChild(0).GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
            _slot.slotDisplay.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }


    }

    private void UpdateSlot()
    {

    }

    public abstract void CreateSlots();
    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnEnter(GameObject obj)
    {
        MouseData.ItemHovered = obj;
    }
    public void OnEnterInterface(GameObject obj)
    {
        MouseData.Ui = obj.GetComponent<UserInterface>();
    }
    public void OnExitInterface(GameObject obj)
    { 
        MouseData.Ui = null;
    }
    public void OnExit(GameObject obj)
    {
        MouseData.ItemHovered = null;
    }
    public void OnBeginDrag(GameObject obj)
    {
        MouseData.ItemBeginDragged = CreateTempItem(obj);
    }
    public void OnDrag(GameObject obj)
    {
        if (MouseData.ItemBeginDragged != null)
        {
            MouseData.ItemBeginDragged.GetComponent<RectTransform>().position = Input.mousePosition;
        }
       
    }
    public void OnEndDrag(GameObject obj)
    {
        Destroy(MouseData.ItemBeginDragged);
        if(MouseData.Ui == null)
        {
            slotOnInterface[obj].RemoveItem();
            return;
        }
        if(MouseData.ItemHovered)
        {
            InventorySlot mouseHoverSlot = MouseData.Ui.slotOnInterface[MouseData.ItemHovered];
            inventory.SwapItems(slotOnInterface[obj],mouseHoverSlot);
        }
    }
    public GameObject CreateTempItem(GameObject obj)
    {
        GameObject tempItem = null;
        if (slotOnInterface[obj].item.Id >=0 )
        {
            tempItem = new GameObject();
            var rt = tempItem.AddComponent<RectTransform>();
            rt.sizeDelta = new Vector2(90, 90);
            tempItem.transform.SetParent(transform.parent);
            var img = tempItem.AddComponent<Image>();
            img.sprite = slotOnInterface[obj].itemData.image;
            img.raycastTarget = false;
        }
        return tempItem;
    }
}

public static class MouseData
{
    public static UserInterface Ui;
    public static GameObject ItemBeginDragged;
    public static GameObject ItemHovered;
}
