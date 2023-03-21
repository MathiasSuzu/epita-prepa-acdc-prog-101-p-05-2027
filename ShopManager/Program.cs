using ShopManager.Products;
using System;
using ShopManager;
using ShopManager.Products.Food;
using ShopManager.Products.Wine;
using ShopManager.Products.Artwork;
using static ShopManager.ShopConsole;

Product[] li = new Product[] { new Seafood(10), new Moussaka(4), new Feta(12), new CopperKylix(true) };
Shop shop = new Shop(1000, li);

/*ShoppingList list = new ShoppingList(1200);
list.AddItem(new ShoppingItem("Seafood", 1));
list.AddItem(new ShoppingItem("Feta", 14));
list.AddItem(new ShoppingItem("Moussaka", 1));
list.AddItem(new ShoppingItem("Kefalotyri", 3));
list.AddItem(new ShoppingItem("CopperKylix", 1));
list.AddItem(new ShoppingItem("CopperKylix", 1));
list.AddItem(new ShoppingItem("Feta", -3));
list.AddItem(new ShoppingItem("Feta", 9));


shop.UseShoppingList(list);*/

ShowInventory(shop);
ShowInfo(shop);

ShowInfo(shop);
ShowInfo(shop);