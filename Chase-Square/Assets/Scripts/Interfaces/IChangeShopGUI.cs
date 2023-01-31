internal interface IChangeShopGUI<T> where T : Item
{
   void ChangeDesign(T[] item, int actuelItem);

}