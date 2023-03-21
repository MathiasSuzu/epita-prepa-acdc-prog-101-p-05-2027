using System;
namespace ShopManager.Products.Food
{
    public class Moussaka : Food
    {
        public override float Price => 30;

        public Moussaka(int quantity = 1)
        {
            Quantity = quantity;
        }
    }
}