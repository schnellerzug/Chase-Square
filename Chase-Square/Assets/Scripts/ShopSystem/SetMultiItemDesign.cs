using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SetMultiItemDesign : MonoBehaviour, IChangeShopGUI<PowerUp>
{
    [SerializeField] private Text[] nameText;
    [SerializeField] private Text[] priceTag;
    [SerializeField] private Button[] buyButton;

    [SerializeField] private UnityEvent<int> onBuyClick;
    public void ChangeDesign(PowerUp[] item, int actuelItem)
    {
        print("hg");
        for (int i = 0; i < item.Length; i++)
        {
            print("fzsg");
            if (nameText.Length > i) nameText[i].text = item[i].itemName;
            if (priceTag.Length > i) priceTag[i].text = item[i].price.ToString();
            print(i);
            if (buyButton.Length > i) buyButton[i].onClick.AddListener(() => onBuyClick?.Invoke(i));
            
        }


      
    }
}
