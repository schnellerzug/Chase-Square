using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Bool Event Channel")]
public class BoolEventChannelSO : ScriptableObject
{
    public UnityAction<bool> OnBoolEventRequested;

    public void RaiseEvent(bool value)
    {
        if (OnBoolEventRequested != null)
        {
            OnBoolEventRequested.Invoke(value);
        }
        else
        {
            Debug.LogWarning("A Scene loading was requested, but nobody picked it up." +
                "Check why there is no SceneLoader already present, " +
                "and make sure it's listening on this Load Event channel.");
        }
    }
}
