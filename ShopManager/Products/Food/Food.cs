using System;

namespace ShopManager.Products.Food
{
    public abstract class Food : Stackable
    {
        public override float SaleFactor => 1.2f;

        public override string GetInfo()
        {
            return "Name: " + Name + "\nPrice: " + Price + "\nQuantity: " + Quantity + "\n";
        }

        public override string ToString() => Name;
    }
}