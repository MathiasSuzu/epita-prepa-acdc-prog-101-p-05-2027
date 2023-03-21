using System;
using ShopManager.Products;

namespace ShopManager
{
    public class ShoppingItem
    {
        public readonly string Name;
        public readonly int Quantity;

        public ShoppingItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
    public class ShoppingList
    {
        public float Budget { get; set; }
        public ShoppingItem[] Items { get; private set; }

        public ShoppingList(int budget)
        {
            Budget = budget;
            Items = Array.Empty<ShoppingItem>();
        }

        public ShoppingList(int budget, ShoppingItem[] items)
        {
            Budget = budget;
            Items = items;
        }


        public void AddItem(ShoppingItem item)
        {
            ShoppingItem[] add = new ShoppingItem[Items.Length+1];

            for (int i = 0; i < Items.Length; i++)
            {
                add[i] = Items[i];
            }

            add[Items.Length] = item;

            Items = add;
        }
    }
}