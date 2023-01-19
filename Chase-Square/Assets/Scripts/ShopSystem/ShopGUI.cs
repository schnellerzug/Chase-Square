
using UnityEngine;
using UnityEngine.UI;

public abstract class ShopGUI<T> : MonoBehaviour where T : Item
{
    [Header("EventChannels")]
    [SerializeField] private VoidEventChannelSO _buyEventChannel;
    [SerializeField] private TypeEventChannelSO<T> _actuelChangeEventChannel;
    [SerializeField] private TypeEventChannelSO<Sprite[]> _createDesignsEvent;
    [SerializeField] private IntEventChannelSO _changeActuelItem;
    [SerializeField] private BuyFeedbackChannelSO _buyFeedback;

    [Header("GUI")]
    [SerializeField] private Button buyButton;

    private IMoveDesign _moveDesign;
    private IChangeShopGUI<T> _changeDesign;
    private ICreateDesign _createDesign;

    private void OnEnable()
    {
        buyButton.onClick.AddListener(Buy);
        _actuelChangeEventChannel.OnItemEventRequested += ChangeDesign;
        _buyFeedback.OnBuyFeedback += FeedBack;
        _createDesignsEvent.OnItemEventRequested += CreateDesignForItem;

        _moveDesign = GetComponent<IMoveDesign>();
        _changeDesign = GetComponent<IChangeShopGUI<T>>();
        _createDesign = GetComponent<ICreateDesign>();
        

    }
    private void OnDisable()
    {
        buyButton.onClick.RemoveListener(Buy);
        _actuelChangeEventChannel.OnItemEventRequested -= ChangeDesign;
        _buyFeedback.OnBuyFeedback -= FeedBack;
        _createDesignsEvent.OnItemEventRequested -= CreateDesignForItem;
    }
    private void Buy()
    {
        _buyEventChannel?.RaiseEvent();
    }

    void ChangeDesign(T item)
    {
        _changeDesign?.ChangeDesign(item);
    }

    public void Move(int amount)
    {
        _changeActuelItem?.RaiseEvent(amount);
        _moveDesign?.Move(amount, 0);
    }

    private void FeedBack(bool value,string reason )
    {
        
        print(value + reason);
    }

    void CreateDesignForItem(Sprite[] sprites)
    {
        print(sprites.Length);
        var objects = _createDesign?.CreateDesign(sprites);
        _moveDesign?.StartPosition(sprites);
        Move(0);
    }  
}
