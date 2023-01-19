using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChangeGUI : MonoBehaviour, IChangeShopGUI<Skin>
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text priceTag;
    [SerializeField] private Text statusText;
    public void ChangeDesign(Skin item)
    {
        if(nameText != null) nameText.text = item.name;
        if(priceTag != null) priceTag.text = item.price.ToString();

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
