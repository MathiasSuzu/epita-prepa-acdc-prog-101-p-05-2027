using System;
namespace ShopManager.Products.Wine
{
    public class GodBlood : Wine
    {
        protected override float PriceFactor => 4;

        public GodBlood(int age = 100, int quantity = 1)
        {
            Age = age;
            Quantity = quantity;
        }
    }
}