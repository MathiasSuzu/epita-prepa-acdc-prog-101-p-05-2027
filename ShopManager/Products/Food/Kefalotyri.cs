using System;
namespace ShopManager.Products.Food
{
    public class Kefalotyri : Food
    {
        public override float Price => 40;

        public Kefalotyri(int quantity = 1)
        {
            Quantity = quantity;
        }
    }
}