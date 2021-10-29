using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct AttributesInItem
{
    [SerializeField] Attributes Atribute;
    [SerializeField] int ValueOfAttribute;
}

[CreateAssetMenu(fileName = "New Armor", menuName = "Items/Create Armor")]
public class ArmorItem : Item2
{
    [SerializeField] EquipmentType Type;

    [SerializeField] AttributesInItem[] AddAtributes; 

    [NaughtyAttributes.MinMaxSlider(0, 100)]
    [SerializeField] Vector2Int Defence;

    [SerializeField] DamageTypes[] DefenceType;
}
