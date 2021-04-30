using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConsumableType
{
    None,
    Food,
    Tonic,
    HealthPotion,
    ManaPotion,
    Poison,

}
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/ConsumableType")]
public class ConsumableItem : Item
{
    public ConsumableType ConsumableType;
    [Space]
    public int HPRegen;
    public int MPRegen;
    [Space]
    public int HPInstantRegen;
    public int MPInstantRegen;
    public float Duration;
    [Space]
    public int VitalityStatBonus;
    public int StrengthStatBonus;
    public int IntelligenceStatBonus;
    public int AgilityStatBonus;
    [Space]
    public float PercentStrengthStatBonus;
    public float PercentIntelligenceStatBonus;
    public float PercentAgilityStatBonus;
    public float PercentVitalityStatBonus;

}
