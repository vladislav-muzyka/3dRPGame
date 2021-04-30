using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class InventorySlot : MonoBehaviour, IDropHandler, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] Image icon;
    [SerializeField] Sprite defaultSprite;
    private Color normalColor = Color.white;
    private Color disabledColor = new Color(1, 1, 1, 0);
    private Color defaultEquipmentColor = new Color(1, 1, 1, 0.3921569f);

    Vector2 originalPosition;
    public event Action<InventorySlot> OnRightClickEvent;
    public event Action<InventorySlot> OnDragEvent;
    public event Action<InventorySlot> OnDropEvent;
    public event Action<InventorySlot> OnBeginDragEvent;
    public event Action<InventorySlot> OnEndDragEvent;

    Item item;
    public Item Item
    {
        get { return item; }
        set
        {
            item = value;
            if (item == null)
            {
                icon.color = disabledColor;
                icon.sprite = defaultSprite;
                if (icon.sprite = defaultSprite)
                    icon.color = defaultEquipmentColor;
            }
            else
            {
                icon.sprite = item.icon;
                icon.color = normalColor;
            }
        }
    }

    public virtual bool CanReceiveItem(Item item)
    {
        return true;
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;

    }


    private void OnLeftClick()
    {
        Debug.Log("LeftClick");
    }
    private void OnRightlick()
    {
        if (item != null && OnRightClickEvent != null)
        {
            item.Use();
            OnRightClickEvent(this);
        }
        Debug.Log("Rightlick");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
            OnLeftClick();
        else if (eventData.button == PointerEventData.InputButton.Right)
            OnRightlick();
    }

    public void OnRemoveButton()//delete from inventory
    {
        Inventory.inctance.Remove(item);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragEvent != null)
            OnDragEvent(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragEvent != null)
            OnBeginDragEvent(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (OnEndDragEvent != null)
            OnEndDragEvent(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropEvent != null)
            OnDropEvent(this);
    }

}
