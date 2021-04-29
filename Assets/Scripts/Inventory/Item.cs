 
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    public int ID = 1;
    new public string name = "New name";
    public Sprite icon = null;
    public bool isDefaultItem = false;



    public virtual void Use()
    {
        Debug.Log("Using "+ name);

    }
}
