using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinChangeGUI : MonoBehaviour, IChangeShopGUI<Skin>
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text priceTag;
    [SerializeField] private Text statusText;

    [SerializeField] private Button buyButon;
    public UnityEvent<int> onBuyClick;
    public void ChangeDesign(Skin[] items, int actuelItem)
    {
        var item = items[actuelItem];   
        if(nameText != null) nameText.text = item.itemName;
        if(priceTag != null) priceTag.text = item.price.ToString();
        buyButon.onClick.RemoveAllListeners();
        buyButon.onClick.AddListener(() => onBuyClick.Invoke(actuelItem));
        if (statusText == null)
            return;

        switch(item.shopState)
        {
            case Skin.ShopState.notBuyed :
                statusText.text = "Buy";
                break;
            case Skin.ShopState.equiped:
                statusText.text = "Equiped";
                break;
            case Skin.ShopState.buyed:
                statusText.text = "Equip";
                break;
        }
    }
}
