
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Int Event Channel")]
public class IntEventChannelSO : ScriptableObject
{
    public UnityAction<int> OnIntEventRequested;

    public void RaiseEvent(int num)
    {
        if (OnIntEventRequested != null)
        {
            OnIntEventRequested.Invoke(num);
        }
        else
        {
            Debug.LogWarning("A Scene loading was requested, but nobody picked it up." +
                "Check why there is no SceneLoader already present, " +
                "and make sure it's listening on this Load Event channel.");
        }
    }
}
