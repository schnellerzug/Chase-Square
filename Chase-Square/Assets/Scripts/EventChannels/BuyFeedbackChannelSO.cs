using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/BuyFeedback Event Channel")]
public class BuyFeedbackChannelSO : ScriptableObject
{
    public UnityAction<bool, string> OnBuyFeedback;

    public void RaiseEvent(bool value, string reason)
    {


        OnBuyFeedback?.Invoke(value, reason);


    }
}
