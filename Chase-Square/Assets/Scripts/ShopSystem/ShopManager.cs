using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShopManager<T> : MonoBehaviour where T : Item
{
    [Header("EventsChannels")]
    [SerializeField] private IntEventChannelSO _changeInt;
    [SerializeField] private TypeEventChannelSO<T> _changeDesign;
    [SerializeField] private TypeEventChannelSO<Sprite[]> _createDesign;
    [SerializeField] private IntEventChannelSO _buyEvent;
    [SerializeField] private BuyFeedbackChannelSO _buyFeedback;

    [SerializeField] private ShopData<T> shopData;


    private IAmABuyCondition<T> _buyCondition;

    private void OnEnable()
    {
        _changeInt.OnIntEventRequested += ChangeActuelItem;
        _buyEvent.OnIntEventRequested += Buy;

        _buyCondition = GetComponent<IAmABuyCondition<T>>();
        

    }
    private void Start()
    {
        SetAll();
    }
    private void OnDisable()
    {
        _changeInt.OnIntEventRequested -= ChangeActuelItem;
        _buyEvent.OnIntEventRequested -= Buy;
    }


    private void Buy(int actuelItem)
    {
        if (_buyCondition.CheckCondition(shopData.shopItems[actuelItem]))
        {
            _buyFeedback.RaiseEvent(true, _buyCondition.ReasonText);
            shopData.shopItems[actuelItem].Buy();
            _changeDesign.RaiseEvent(shopData.shopItems[actuelItem]);
            return;

        }

            _buyFeedback.RaiseEvent(false, _buyCondition.ReasonText);
        
    }

    void SetAll()
    {
        var icons = new List<Sprite>();
        foreach (var item in shopData.shopItems)
        {
            icons.Add(item.icon);
        }
        print(icons.ToArray());
        _createDesign.RaiseEvent(icons.ToArray());
    }

    private void ChangeActuelItem(int amount)
    {
        //actuelItem += amount;
        //if(actuelItem >= shopData.shopItems.Length)
        //    actuelItem = 0;
        //else if(actuelItem < 0)
        //    actuelItem = shopData.shopItems.Length-1;

        //_changeDesign.RaiseEvent(shopData.shopItems[actuelItem]);
    }
}
