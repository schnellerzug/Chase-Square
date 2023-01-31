internal interface IAmABuyCondition<T> where T : Item
{
    

    string ReasonText { get; set; }

    bool CheckCondition(T item);
}