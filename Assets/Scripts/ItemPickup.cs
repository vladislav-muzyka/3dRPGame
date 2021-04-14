using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactible
{
    public Item item;
    public override void Interact()
    {
        base.Interact();
        Pickup();
    }

    private void Pickup()
    {
        Debug.Log("Item: " + item.name + " was picked up");
        Destroy(gameObject);
    }
}
