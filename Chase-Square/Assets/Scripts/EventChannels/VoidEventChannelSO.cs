using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Void Event Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    public UnityAction OnVoidEventRequested;

    public void RaiseEvent()
    {
        if (OnVoidEventRequested != null)
        {
            OnVoidEventRequested.Invoke();
        }
        else
        {
            Debug.LogWarning("A Scene loading was requested, but nobody picked it up." +
                "Check why there is no SceneLoader already present, " +
                "and make sure it's listening on this Load Event channel.");
        }
    }
}
