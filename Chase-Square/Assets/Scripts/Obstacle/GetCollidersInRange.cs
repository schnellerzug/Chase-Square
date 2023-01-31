
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GetCollidersInRange : MonoBehaviour, IGetAvailableObject<Collider2D>
{
    [SerializeField] private float range;
    

    public Collider2D[] GetObjects(int amount)
    {
        
        var objects = Physics2D.OverlapCircleAll(transform.position, range);
        return objects;

    }
}
