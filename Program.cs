using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            shop shop = new shop();
        }
    }

    class Products
    {
        public uint Id;
        public string NameProduct { get; set; }
        public float Prise { get; set; }
        public uint Quantity { get; set; }


        public Products() {}

        public Products(uint id, string nameProduct, float prise, uint quantity)
        {
            Id = id;
            NameProduct = nameProduct;
            Prise = prise;
            Quantity = quantity;
        }

        public void PrintProducts()
        {
            Console.WriteLine("Name product: " + NameProduct);
            Console.WriteLine("Prise: " + Prise);
            Console.WriteLine("Quantity: " + Quantity);
        }

        public void CreatProduct()
        {
            Console.Write("Enter name product: ");
            string nameProduct = Console.ReadLine();

            Console.Write("Enter prise: ");
            float prise = Convert.ToSingle((Console.ReadLine()));

            Console.Write("Enter quantity: ");
            uint quantity =Convert.ToUInt32(Console.ReadLine());

            NameProduct = nameProduct;
            Prise = prise; 
            Quantity = quantity;
        }
    }

    class ProductsInShop
    {
        List<Products> ALlProductsInShop = new List<Products>();

        public ProductsInShop()
        {
            var lines = File.ReadAllLines("ProductsInShop.txt");

            foreach (string line in lines)
            {
                var split = line.Split(";");

                Products products = new Products(Convert.ToUInt32(split[0]), split[1], Convert.ToSingle(split[2]), Convert.ToUInt32(split[3]));

                ALlProductsInShop.Add(products);
            }

        }

        public void PrintListProduct()
        {
            foreach (Products products in ALlProductsInShop)
            {
                products.PrintProducts();
                Console.WriteLine();
            }
        }

        public void AddProduct()
        {
            Products product = new Products();
            
            product.CreatProduct();
            product.Id = Convert.ToUInt32(ALlProductsInShop.Count());

            ALlProductsInShop.Add(product);

            File.AppendAllLines(
            "ProductsInShop.txt",
            new[] { $"{product.Id};{product.NameProduct};{product.Prise};{product.Quantity}"});
        }

    }

    class Buyers
    {
        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastdName { get; set; }
        public string Amail { get; set; }

        public Buyers() { }

        public Buyers(uint id, string firstNamem, string lastdName, string amail)
        {
            Id = id;
            FirstName = firstNamem;
            LastdName = lastdName;
            Amail = amail;
        }
        public void RegistrBuyers()
        {
            Console.Write("Enter your name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter name product: ");
            string lastdName = Console.ReadLine();
            Console.Write("Enter name product: ");
            string amail = Console.ReadLine();

            FirstName = firstName;
            LastdName = lastdName;
            Amail = amail;
        }
    }
    class BuyersList
    {
        public List<Buyers> AllBuyersList = new List<Buyers>();


        public BuyersList()
        {
            var lines = File.ReadAllLines("BuyersList.txt");

            foreach (string line in lines)
            {
                var split = line.Split(";");

                Buyers Buyer = new Buyers(Convert.ToUInt32(split[0]), split[1], split[2], split[3]);

                AllBuyersList.Add(Buyer);
            }
        }

        public void RegistrBuyers()
        {
            Buyers buyer = new Buyers();
            buyer.RegistrBuyers();
            buyer.Id = Convert.ToUInt32(AllBuyersList.Count());

            AllBuyersList.Add(buyer);

            File.AppendAllLines(
            "BuyersList.txt",
            new[] { $"{buyer.Id};{buyer.FirstName};{buyer.LastdName};{buyer.Amail}" });
        }
    }

    class Receipts
    {
        public uint Id { get; set; }
        public string NameBuyer { get; set; }
        public string NameProduct { get; set; }
        public float EndlPrise { get; set; }

        public Receipts(uint id, string nameBuyer, string nameProduct, float endlPrise)
        {
            Id = id;
            NameBuyer = nameBuyer;
            NameProduct = nameProduct;
            EndlPrise = endlPrise;
        }


        public void PrintReceipts()
        {
            Console.WriteLine("Buyer name " + NameBuyer);
            Console.WriteLine("Products buy: " + NameProduct);
            Console.WriteLine("Endl prise: " + EndlPrise);
        }
    }

    class ReceiptsList
    {
        List<Receipts> AllReceiptsList = new List<Receipts>();

        public ReceiptsList()
        {
            var lines = File.ReadAllLines("ReceiptsList.txt");

            foreach (string line in lines)
            {
                var split = line.Split(";");

                Receipts products = new Receipts(Convert.ToUInt32(split[0]), split[1], split[2],Convert.ToSingle(split[3]));

                AllReceiptsList.Add(products);
            }
        }

        public void PrintAllReceipts()
        {
            foreach (Receipts products in AllReceiptsList)
            {
                products.PrintReceipts();
                Console.WriteLine();
            }
        }
    }

    class shop
    {
        BuyersList BuyersList = new BuyersList();
        ReceiptsList ReceiptsList =new ReceiptsList();
        ProductsInShop ProductsInShop = new ProductsInShop();

        public shop()
        {
            string result;
            do
            {
                Console.WriteLine("1.Add product.\n" +
                                  "2.Registr buer.\n" +
                                  "3.Print all product.\n" +
                                  "4.Print all receipts.\n" +
                                  "5.End.");
                 result = Console.ReadLine();

                switch (result)
                {
                    case "1":
                        Console.WriteLine();
                        ProductsInShop.AddProduct();
                        break;
                    case "2":
                        Console.WriteLine();
                        BuyersList.RegistrBuyers();
                        break;
                    case "3":
                        Console.WriteLine();
                        ProductsInShop.PrintListProduct();
                        break;
                    case "4":
                        Console.WriteLine();
                        ReceiptsList.PrintAllReceipts();
                        break;
                }

            } while (result != "5");
        }
    }

}
