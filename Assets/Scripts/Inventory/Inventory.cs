using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event Action<InventorySlot> OnRightClickEvent;
    public event Action<InventorySlot> OnDragEvent;
    public event Action<InventorySlot> OnDropEvent;
    public event Action<InventorySlot> OnBeginDragEvent;
    public event Action<InventorySlot> OnEndDragEvent;

    InventoryUI inventoryUI;
    #region Singleton
    public static Inventory inctance;
    private void Awake()
    {
        if (inctance != null)
        {
            Debug.LogError("more than one inventory");
            return;
        }
        inctance = this;

        inventoryUI = GameObject.Find("Canvas").GetComponent<InventoryUI>();
    }
    #endregion

    [SerializeField] private int inventoryCapacity;
    public List<Item> items = new List<Item>();
    public delegate void OnItemChanged();
    public  OnItemChanged onItemChangedCallback;



    private void Start()
    {
        for (int i = 0; i < inventoryUI.slots.Length; i++)
        {
            inventoryUI.slots[i].OnRightClickEvent += OnRightClickEvent;
            inventoryUI.slots[i].OnDragEvent += OnDragEvent;
            inventoryUI.slots[i].OnDropEvent += OnDropEvent;
            inventoryUI.slots[i].OnBeginDragEvent += OnBeginDragEvent;
            inventoryUI.slots[i].OnEndDragEvent += OnEndDragEvent;
}
    }
    public bool Add(Item item)
    {
        for (int i = 0; i < inventoryUI.slots.Length; i++)
        {
            if (inventoryUI.slots[i].Item == null)
            {
                inventoryUI.slots[i].Item = item;
                return true;
            }  
        }
        return false;
    }

    public bool Remove(Item item)
    {
        for (int i = 0; i < inventoryUI.slots.Length; i++)
        {
            if (inventoryUI.slots[i].Item == item)
            {
                inventoryUI.slots[i].Item = null;
                return true;
            }
        }
        return false;
    }

    public bool IsFull()
    {
        for (int i = 0; i < inventoryUI.slots.Length; i++)
        {
            if (inventoryUI.slots[i].Item == null)
            {
                return false;
            }
        }
        return true;
    }
}
