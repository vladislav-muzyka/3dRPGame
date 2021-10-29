using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Create Weapon")]
public class WeaponItem : Item2
{

    [NaughtyAttributes.ShowAssetPreview]
    [SerializeField] GameObject Mesh;

    [NaughtyAttributes.MinMaxSlider(0, 100)]
    [SerializeField] Vector2Int Damage;

    [SerializeField] DamageTypes[] DamageType;
}
