using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory inctance;
    private void Awake()
    {
        if (inctance != null)
        {
            Debug.LogError("morethan one inventory");
            return;
        }
        inctance = this;
    }
    #endregion

    [SerializeField] private int inventoryCapacity;
    public List<Item> items = new List<Item>();
    public delegate void OnItemChanged();
    public  OnItemChanged onItemChangedCallback;

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= inventoryCapacity)
            {
                Debug.Log("Not enough space");
                return false;
            }
            items.Add(item);
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        if (!item.isDefaultItem)
        {
            items.Remove(item);
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }
}
