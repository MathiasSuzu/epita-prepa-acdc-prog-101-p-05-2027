using System;
using System.ComponentModel.Design;

namespace ShopManager
{
    public static class ShopConsole
    {
        public static void PrintSeparator()
        {
            Console.WriteLine("========================");
        }
        
        public static int ShowMenu(Shop shop)
        {
            PrintSeparator();
            Console.WriteLine("Your actual balance: " + shop.Balance + "Δρ.");
            
            Console.Write("1) Sell\n2) Buy\n3) Show inventory\n4) Product's stock\n5) Use shopping list\n6) Exit\nYour choice: ");
            
            int select = Console.Read() - 48;
            while (select < 1 || select> 6)
            {
                //inutilie si je dois 
                if(select < -15)
                    select = Console.Read() - 48;
                else
                {
                    Console.Error.WriteLine("Invalid input");
                    Console.Write("1) Sell\n2) Buy\n3) Show inventory\n4) Product's stock\n5) Use shopping list\n6) Exit\nYour choice: ");
                    select = Console.Read() - 48;
                }
                
            }

            return select;
        }
        
        public static void PressToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        
        public static void ShowInventory(Shop shop)
        {
            PrintSeparator();
            Console.WriteLine("Inventory:");
            foreach ((string, int) current in shop.GetStock())
            {
                Console.WriteLine("    - " + current.Item1 + " (" + current.Item2 + " item in stock)");
            }
            PressToContinue();
        }
        
        public static void ShowInfo(Shop shop)
        {
            PrintSeparator();
            Console.Write("Enter product name: ");
            string select = Console.ReadLine();

            shop.ShowInfo(select);
            PressToContinue();
        }
        
        public static int ShowProducts((string Name, int Quantity)[] products, string action)
        {
            PrintSeparator();
            Console.WriteLine("What do you want to " + action + ":");
            Console.WriteLine("c) Cancel action");
            int i = 0;
            for (; i < products.Length; i++)
            {
                Console.WriteLine(i + ") " + products[i]);
            }
            Console.Write("Your choice: ");
            int res = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return res;
        }
        
        public static void Buy(Shop shop)
        {
            throw new NotImplementedException();
        }
        
        public static void Sell(Shop shop)
        {
            throw new NotImplementedException();
        }
        
        public static void HandleShoppingList(Shop shop)
        {
            throw new NotImplementedException();
        }
        
        public static void Run(Shop shop)
        {
            throw new NotImplementedException();
        }
        
    }
}