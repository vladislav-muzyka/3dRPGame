using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] Image draggableItem;
    InventorySlot draggedSlot;

    private void Awake()
    {
        //equip
        inventory.OnRightClickEvent += Equip;
        equipmentPanel.OnRightClickEvent += UnEquip;
        //beging drag
        inventory.OnBeginDragEvent += BeginDrag;
        equipmentPanel.OnBeginDragEvent += BeginDrag;
        //end drag
        inventory.OnEndDragEvent += EndDrag;
        equipmentPanel.OnEndDragEvent += EndDrag;
        //drag
        inventory.OnDragEvent += Drag;
        equipmentPanel.OnDragEvent += Drag;
        //drop
        inventory.OnDropEvent += Drop;
        equipmentPanel.OnDropEvent += Drop;
    }

    private void BeginDrag(InventorySlot inventorySlot)
    {
        if (inventorySlot.Item != null)
        {
            draggedSlot = inventorySlot;
            draggableItem.sprite = inventorySlot.Item.icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }
    }

    private void EndDrag(InventorySlot inventorySlot)
    {
        draggedSlot = null;
        draggableItem.enabled = false;
    }

    private void Drag(InventorySlot inventorySlot)
    {
        if (draggableItem.enabled)
        {
            draggableItem.transform.position = Input.mousePosition;
        }
    }

    private void Drop(InventorySlot dropInventorySlot)
    {
        if (dropInventorySlot.CanReceiveItem(draggedSlot.Item) && draggedSlot.CanReceiveItem(dropInventorySlot.Item))
        {
            EquipibleItem dragItem = draggedSlot.Item as EquipibleItem;
            EquipibleItem dropItem = dropInventorySlot.Item as EquipibleItem;
            if (draggedSlot is EquipmentSlot)
            {
                if (dragItem != null)
                    dragItem.UnEquip(this);
                if (dropItem != null)
                    dropItem.Equip(this);
            }
            if (dropInventorySlot is EquipmentSlot)
            {
                if (dragItem != null)
                    dragItem.Equip(this);
                if (dropItem != null)
                    dropItem.UnEquip(this);
            }

            Item draggedItem = draggedSlot.Item;
            draggedSlot.Item = dropInventorySlot.Item;
            dropInventorySlot.Item = draggedItem;
        }
    }

    public void Equip(InventorySlot inventorySlot)
    {
        EquipibleItem equipibleItem = inventorySlot.Item as EquipibleItem;
        if (equipibleItem != null)
        {
            Equip(equipibleItem);
        }
    }

    public void UnEquip(InventorySlot inventorySlot)
    {
        EquipibleItem equipibleItem = inventorySlot.Item as EquipibleItem;
        if (equipibleItem != null)
        {
            UnEquip(equipibleItem);
        }
    }
    //private void EquipFromInventory(Item item)
    //{
    //    if (item is EquipibleItem)
    //    {
    //        Equip((EquipibleItem)item);
    //    }
    //    else if (item is ConsumableItem)
    //    {
    //        Consume((ConsumableItem)item);
    //    }
    //}

    //private void UnEquipFromInventory(Item item)
    //{

    //    if (item is EquipibleItem)
    //    {
    //        UnEquip((EquipibleItem)item);
    //    }
    //}
    public void Consume(ConsumableItem item)
    {
        Debug.Log("You consume " + item.name);
        inventory.Remove(item);
    }
    public void Equip(EquipibleItem item)
    {
        if (inventory.Remove(item))
        {
            EquipibleItem previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.Add(previousItem);
                    previousItem.UnEquip(this);
                }
                item.Equip(this);
            }
            else
            {
                inventory.Add(item);
            }
        }
    }

    public void UnEquip(EquipibleItem item)
    {
        if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            item.UnEquip(this);
            inventory.Add(item);
        }

    }

}
