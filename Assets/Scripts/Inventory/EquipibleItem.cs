using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/EquipibleItem")]
public class EquipibleItem : Item
{
    public EquipmentType EquipmentType;
    [Space]
    public int StrengthStat;
    public int IntelligenceStat;
    public int AgilityStat;
    public int VitalityStat;
    [Space]
    public float PercentStrengthStat;
    public float PercentIntelligenceStat;
    public float PercentAgilityStat;
    public float PercentVitalityStat;

    public void Equip(InventoryManager stats)
    { 
    
    }
    public void UnEquip(InventoryManager stats)
    {

    }
}