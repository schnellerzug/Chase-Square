using UnityEngine;

internal interface IGetAvailableObjectFromList<T> where T : MonoBehaviour
{
    public T GetAvailableObject(T[] objects, T obstacle);
}