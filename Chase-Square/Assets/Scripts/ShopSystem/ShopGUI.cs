
using UnityEngine;

public abstract class ShopGUI<T> : MonoBehaviour where T : Item
{
    [SerializeField] private ShopData<T> data;

    [Header("EventChannels")]
    [SerializeField] private IntEventChannelSO _buyEventChannel;
    //[SerializeField] private TypeEventChannelSO<T[]> _actuelChangeEventChannel;
    [SerializeField] private TypeEventChannelSO<Sprite[]> _createDesignsEvent;
    [SerializeField] private IntEventChannelSO _changeActuelItem;
    [SerializeField] private BuyFeedbackChannelSO _buyFeedback;

    private int actuelItem;

    private IMoveDesign _moveDesign;
    private IChangeShopGUI<T> _changeDesign;
    private IShowText _showText;

    private void OnEnable()
    {
        //buyButton.onClick.AddListener(Buy);
        //_actuelChangeEventChannel.OnItemEventRequested += ChangeDesign;
        _buyFeedback.OnBuyFeedback += FeedBack;
        _createDesignsEvent.OnItemEventRequested += CreateDesignForItem;

        _moveDesign = GetComponent<IMoveDesign>();
        _changeDesign = GetComponent<IChangeShopGUI<T>>();
        _showText = GetComponent<IShowText>();
        

    }
    private void OnDisable()
    {
        //buyButton.onClick.RemoveListener(Buy);
        //_actuelChangeEventChannel.OnItemEventRequested -= ChangeDesign;
        _buyFeedback.OnBuyFeedback -= FeedBack;
        _createDesignsEvent.OnItemEventRequested -= CreateDesignForItem;
    }
    public void Buy(int value)
    {
        _buyEventChannel?.RaiseEvent(value);
    }

    void ChangeDesign()
    {
        _changeDesign?.ChangeDesign(data.shopItems, actuelItem);
    }

    public void Move(int amount)
    {
        actuelItem += amount;
        if (actuelItem >= data.shopItems.Length)
            actuelItem = 0;
        else if (actuelItem < 0)
            actuelItem = data.shopItems.Length - 1;

        //_changeActuelItem?.RaiseEvent(amount);
        ChangeDesign();
        _moveDesign?.Move(amount, 0);
    }


    private void FeedBack(bool value,string reason )
    {
        _showText.Show(reason,value? Color.green : Color.red);
        print(value + reason);
    }

    void CreateDesignForItem(Sprite[] sprites)
    {
        print(sprites.Length);
        _moveDesign?.StartPosition(sprites);
        Move(0);
    }  
}
