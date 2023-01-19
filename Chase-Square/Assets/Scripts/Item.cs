using UnityEngine;

public abstract class Item : ScriptableObject
{
    public Sprite icon;
    public string itemName;
    public int price;

    public virtual void Buy()
    {

    }

    public virtual void Use()
    {
        
    }

}