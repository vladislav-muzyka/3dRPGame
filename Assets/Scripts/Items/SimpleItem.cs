using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Create Simple Item")]
public class SimpleItem : Item2
{
    [SerializeField] SimpleItems ItemType;

    [SerializeField] AttributesInItem[] AddAtributes;

    [Tooltip("Default Instant Regen")]
    [SerializeField] bool TimeRegen;
    [NaughtyAttributes.ShowIf("TimeRegen")]
    [SerializeField] float Time;
}
