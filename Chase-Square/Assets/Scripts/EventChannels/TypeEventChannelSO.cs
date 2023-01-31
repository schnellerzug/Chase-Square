using UnityEngine;
using UnityEngine.Events;


public abstract class TypeEventChannelSO<T> : ScriptableObject
{
    public UnityAction<T> OnItemEventRequested;

    public void RaiseEvent(T item)
    {
        if (OnItemEventRequested != null)
        {
            OnItemEventRequested?.Invoke(item);
        }
        else
        {
            Debug.LogWarning("A Scene loading was requested, but nobody picked it up." +
                "Check why there is no SceneLoader already present, " +
                "and make sure it's listening on this Load Event channel.");
        }
    }
}