using System;
using ShopManager.Products;
using ShopManager.Products.Artwork;

namespace ShopManager
{
    public class Shop
    {
        public float Balance { get; private set; }
        public Product[] Products { get; }

        public Shop(float balance, Product[] products)
        {
            Balance = balance;
            Products = products;
        }


        private void AddMoney(float money) => Balance += money;

        private void RemoveMoney(float money) => Balance -= money;

        public (string Name, int Quantity)[] GetStock()
        {
            int len = Products.Length;
            (string Name, int Quantity)[] result = new (string Name, int Quantity)[len];
            for (int i = 0; i < len; i++)
            {
                if (Products[i] is Artwork)
                    result[i] = (Products[i].ToString(), ((Artwork) Products[i]).InStock ? 1 : 0);
                else if(Products[i] is Stackable)
                    result[i] = (Products[i].ToString(), ((Stackable) Products[i]).Quantity);
            }

            return result;
        }

        public int FindProductByName(string name)
        {
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Name == name)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Buy(int index, int quantity)
        {
            if (index >= Products.Length || index < 0)
                throw new IndexOutOfRangeException();
            
            if (quantity < 0)
                throw new InvalidQuantityException();
            if(quantity == 0)
                return;
            
            if (Products[index] is Artwork)
            {
                if (((Artwork)Products[index]).InStock)
                    throw new NotEnoughItemsException();
                
                else if(quantity > 1)
                    throw new InvalidQuantityException();
                
                else
                {
                    if (Balance < Products[index].Price)
                        throw new NotEnoughMoneyException();
                    
                    ((Artwork)Products[index]).InStock = true;
                    Balance -= Products[index].Price;

                }
            }

            else if(Products[index] is Stackable)
            {
                if(Balance < Products[index].Price * quantity)
                    throw new NotEnoughMoneyException();

                Products[index] = (Stackable)Products[index] + quantity;

                Balance -= Products[index].Price * quantity;

            }
            
        }
        
        public void Buy(string name, int quantity)
        {
            int index = FindProductByName(name);
            if (index == -1)
                throw new IndexOutOfRangeException();
            
            Buy(index,quantity);
        }

        public void Sell(int index, int quantity)
        {
            if (index >= Products.Length || index < 0)
                throw new IndexOutOfRangeException();
            
            if (quantity < 0)
                throw new InvalidQuantityException();
            
            if(quantity == 0)
                return;
            
            if (Products[index] is Artwork)
            {
                if (quantity > 1 || ((Artwork)Products[index]).InStock == false)
                    throw new NotEnoughItemsException();
                
                Balance += ((Artwork)Products[index]).Price * ((Artwork)Products[index]).SaleFactor;
            }
            else if(Products[index] is Stackable)
            {
                if(quantity > ((Stackable)Products[index]).Quantity)
                    throw new NotEnoughItemsException();
                
                Balance += Products[index].Price * Products[index].SaleFactor * quantity;
                
            }
        }

        public void Sell(string name, int quantity)
        {
            int index = FindProductByName(name);
            if (index == -1)
                throw new IndexOutOfRangeException();
            
            Sell(index,quantity);
        }

        public void ShowInfo(string name)
        {
            int index = FindProductByName(name);
            if(index == -1)
                Console.Error.WriteLine("Product '" + name +"' not found");
            else
            {
                Console.WriteLine(Products[index].GetInfo());
            }
        }
        
        public float UseShoppingList(ShoppingList shoppingList)
        {
            foreach (ShoppingItem current in shoppingList.Items)
            {
                try
                {
                    int index = FindProductByName(current.Name);

                    if (Products[index].Price * Products[index].SaleFactor * current.Quantity > shoppingList.Budget)
                        throw new NotEnoughMoneyException();
                    else
                    {
                        Sell(index, current.Quantity);
                        shoppingList.Budget -= Products[index].Price * Products[index].SaleFactor * current.Quantity;
                        Console.WriteLine("Bought " + current.Quantity + " " + current.Name);
                    }

                }
                catch (IndexOutOfRangeException e)
                {
                    Console.Error.WriteLine("Product '" + current.Name + "' not found");
                }
                catch (InvalidQuantityException e)
                {
                    Console.Error.WriteLine("Invalid quantity to buy " + current.Name);
                }
                catch (NotEnoughItemsException e)
                {
                    Console.Error.WriteLine("Not enough items to buy " + current.Name);
                }
                catch (NotEnoughMoneyException e)
                {
                    Console.Error.WriteLine("Not enough money to buy " + current.Name);
                }
            }

            return shoppingList.Budget;
        }
    }
}