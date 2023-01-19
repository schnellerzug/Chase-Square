
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Skin")]
public class Skin : Item
{
    public Sprite skin;
    public ShopState shopState;

    public enum ShopState
    {
        notBuyed,
        buyed,
        equiped
    }

    public override void Buy()
    {
        if(shopState == ShopState.notBuyed)
        {
            shopState = ShopState.buyed;
            return;
        }
        if(shopState == ShopState.buyed ) 
        {
            GameManager.instance.playerSkin.shopState = ShopState.buyed;
            GameManager.instance.playerSkin = this;
            shopState= ShopState.equiped;
        }

    }


}
