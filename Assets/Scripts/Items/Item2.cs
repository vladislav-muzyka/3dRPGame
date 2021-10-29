using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item2 : ScriptableObject
{
    [NaughtyAttributes.ReadOnly]
    [SerializeField] string ID = "";
    [SerializeField] string NameOfItem;
    [SerializeField] string Description;

    [NaughtyAttributes.ShowAssetPreview]
    [SerializeField] Sprite Icon;



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
