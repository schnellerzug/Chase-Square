
using UnityEngine;


public abstract class ShopData<T> : ScriptableObject where T : Item
{
  
    public T[] shopItems; 
    
}



