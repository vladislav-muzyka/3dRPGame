using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotParent;
    [SerializeField] EquipmentSlot[] equipmentSlots;

    public event Action<InventorySlot> OnRightClickEvent;
    public event Action<InventorySlot> OnDragEvent;
    public event Action<InventorySlot> OnDropEvent;
    public event Action<InventorySlot> OnBeginDragEvent;
    public event Action<InventorySlot> OnEndDragEvent;

    private void Awake()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnRightClickEvent += OnRightClickEvent;
            equipmentSlots[i].OnDragEvent += OnDragEvent;
            equipmentSlots[i].OnDropEvent += OnDropEvent;
            equipmentSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            equipmentSlots[i].OnEndDragEvent += OnEndDragEvent;
        }
    }
    private void OnValidate()
    {
        equipmentSlots = equipmentSlotParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public bool AddItem(EquipibleItem equipibleItem, out EquipibleItem previousItem)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].EquipmentType == equipibleItem.EquipmentType)
            {
                previousItem = (EquipibleItem)equipmentSlots[i].Item;
                equipmentSlots[i].Item = equipibleItem;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquipibleItem equipibleItem)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item == equipibleItem)
            {
                equipmentSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }
}
