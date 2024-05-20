using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RuchikaDhudum_Assignment2
{
    public class Item
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Item(int iD, string name, int price, int quantity)
        {
            ID = iD;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"ID : {ID}, Name : {Name}, Price : {Price}, Quantity : {Quantity}";
        }
    }

    public class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine("Item added successfully");
            Console.ReadLine();
        }
        public void DisplayItem()
        {
            if (items.Count > 0)
            {
                foreach (var item1 in items)
                {
                    Console.WriteLine(item1);
                }
            }
            else
            {
                Console.WriteLine("No items found in inventory.");
            }
            Console.ReadLine();
        }

        public Item FindItemById(int id)
        {
            return items.FirstOrDefault(x => x.ID == id);
            
        }

        public void UpdateItem(int id, String name,int price, int quantity)
        {
            var item = FindItemById(id);
            if (item != null)
            {
                item.Name = name;
                item.Price = price;
                item.Quantity = quantity;
                Console.WriteLine("Item updated successfully.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
            Console.ReadLine();
        }

        public void DeleteItem(int id)
        {
            var item = FindItemById(id);
            if(item != null)
            {
                items.Remove(item);
                Console.WriteLine("An item got deleted successfully.");
            }
            else
            {
                Console.WriteLine("item not found.");
            }
            Console.ReadLine();
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            Console.WriteLine("WELCOME TO INVENTORY MANAGEMENT SYSTEM PROJECT.");
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Inventory Management System.");
                Console.WriteLine("Enter 1 : to add an item.");
                Console.WriteLine("Enter 2 : to display all items.");
                Console.WriteLine("Enter 3 : to find item by ID.");
                Console.WriteLine("Enter 4 : to update an item's information.");
                Console.WriteLine("Enter 5 : to deleting an item.");
                Console.WriteLine("Enter 6 : to exit");
                Console.WriteLine();
                Console.WriteLine("select your choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddItem(inventory);
                        break;

                    case 2:
                        inventory.DisplayItem();
                        break;

                    case 3:
                        FindItemById(inventory);
                        break;

                    case 4:
                        UpdateItem(inventory);
                        break;

                    case 5:
                        DeleteItem(inventory);
                        break;

                    case 6:
                        Console.WriteLine("exiting the application....");
                        return; 

                    default:
                        Console.WriteLine("Invalid input!!!..Select correct choice in range of 1 to 6.");
                        break;
                }

            }
        }

        private static void AddItem(Inventory inventory)
        {
            Console.WriteLine("Enter an item ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the name of an item :");
            String name = Console.ReadLine();
            Console.WriteLine("Enter an item price in Rupee: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter an item quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Item item = new Item(id, name, price, quantity);
            inventory.AddItem(item);

        }

        private static void FindItemById(Inventory inventory)
        {
            Console.WriteLine("Enter an item ID No. to find : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Item item = inventory.FindItemById(id);
            {
                if(item != null)
                {
                    Console.WriteLine(item);
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }
            }
        }

        private static void UpdateItem(Inventory inventory)
        {
            Console.WriteLine("Enter an item ID to update : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the name of an item :");
            String name = Console.ReadLine();
            Console.WriteLine("Enter an item price in Rupee: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter an item quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            inventory.UpdateItem(id, name, price, quantity);

        }

        private static void DeleteItem(Inventory inventory)
        {
            Console.WriteLine("Enter an item ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            inventory.DeleteItem(id);
        }


    }
}

