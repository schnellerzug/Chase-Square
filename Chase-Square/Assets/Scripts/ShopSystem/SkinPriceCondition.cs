
using UnityEngine;

public class SkinPriceCondition : MonoBehaviour, IAmABuyCondition<Skin>
{
    public string ReasonText { get; set; }

    public bool CheckCondition(Skin item)
    {
        if(item.shopState == Skin.ShopState.notBuyed)
        {

            if (GameManager.instance.ChangeCoins(-item.price))
            {
                ReasonText = "Buyed";
                return true;
            }
            ReasonText = "Not Enougn Coins";
            return false;
        }
        ReasonText = "Equiped";
        return true;
    }
}
