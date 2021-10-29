using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item2 : ScriptableObject, IMeshItem
{
    [NaughtyAttributes.ReadOnly]
    [SerializeField] string ID = "";
    [SerializeField] string NameOfItem;
    [SerializeField] string Description;

    [NaughtyAttributes.ShowAssetPreview]
    [SerializeField] Sprite Icon;

    [NaughtyAttributes.ShowAssetPreview]
    [SerializeField] GameObject Mesh;

    public GameObject GetItemMesh()
    {
        return Mesh;
    }


#if UNITY_EDITOR

    public void OnValidate()
    {
        if(ID == "")
        {
            ID = UnityEditor.GUID.Generate().ToString();//System.Guid.NewGuid().ToString();
        }
    }
#endif
}
