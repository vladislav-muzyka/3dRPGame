using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] Button removeButton;
    Item item;
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; 
        }
    }

    private void OnLeftClick()
    {
        Debug.Log("OnLeftClick");
    }
    private void OnRightlick()
    {
        UseItem();
        Debug.Log("OnRightlick");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            OnLeftClick();
        else if (eventData.button == PointerEventData.InputButton.Right)
            OnRightlick();
    }

    public void OnRemoveButton()
    {
        Inventory.inctance.Remove(item);

    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }


}
