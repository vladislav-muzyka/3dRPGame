using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : InventorySlot
{
    public EquipmentType EquipmentType;

    private void OnValidate()
    {
        gameObject.name = EquipmentType.ToString() + " Slot";
    }

    public override bool CanReceiveItem(Item item)
    {
        if (item == null)
            return true;

        EquipibleItem equipibleItem = item as EquipibleItem;
        return equipibleItem != null && equipibleItem.EquipmentType == EquipmentType;
    }
}
