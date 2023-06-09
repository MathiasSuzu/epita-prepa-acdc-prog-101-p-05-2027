using System;

namespace ShopManager.Products
{
    public abstract class Stackable : Product
    {
        public int Quantity { get; protected set; }

        public static Stackable operator +(Stackable stack, int quantity)
        {
            Stackable result = (Stackable) stack.MemberwiseClone();
            result.Quantity += quantity;
            return result;
        }

        public static Stackable operator -(Stackable stack, int quantity)
        {
            Stackable result = (Stackable) stack.MemberwiseClone();
            result.Quantity -= quantity;
            return result;
        }
    }
}