
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Skin")]
public class Skin : Item
{
    [Header("SkinData")]
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
            Use();
        }

    }
    public override void Use()
    {
        GameManager.instance.playerSkin.StopUse();
        GameManager.instance.playerSkin = this;
        shopState = ShopState.equiped;
    }

    public override void StopUse()
    {
        GameManager.instance.playerSkin = null;
        shopState= ShopState.buyed;
    }


}
