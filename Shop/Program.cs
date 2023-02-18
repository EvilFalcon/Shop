using System;
using System.Collections.Generic;

namespace Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop _shop = new Shop();
            Player player = new Player();

            _shop.Work(player);
        }
    }

    class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }
    }

    class Shop
    {
        private Salesperson _seller;
        Player _player;

        public Shop()
        {
            _seller = new Salesperson(CreateProduct());
        }

        public void Work(Player player)
        {
            const string CommandBuyItem = "1";
            const string CommandLookInventory = "2";
            const string CommandExitProgram = "3";

            

            _player = player;

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"{CommandBuyItem} купить предмет");
                Console.WriteLine($"{CommandLookInventory} посмотреть свою сумку");
                Console.WriteLine($"{CommandExitProgram} выход программы\n\n\n");

                _seller.ShowInfo();

                switch (Console.ReadLine())
                {
                    case CommandBuyItem:
                        Trade();
                        break;

                    case CommandLookInventory:
                        _player.ShowInfo();
                        break;

                    case CommandExitProgram:
                        isWork = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Trade()
        {
            if (_seller.TryGetProduct(out Product product) == false)
            {
                return;
            }

            if (_player.CanPay(product.Price) == false)
            {
                return;
            }

            _player.Buy(product);
            _seller.Sell(product);
        }

        private List<Product> CreateProduct()
        {
            List<Product> products = new List<Product>()
            {
                new Product("меч",500),
                new Product("щит",250),
                new Product("кожаный доспех",100),
                new Product("кольчуга",500),
                new Product("латы",1000),
                new Product("кожаный шлем",50),
                new Product("латный шлем",400),
                new Product("кожаные перчатки",40),
                new Product("латные перчатки",350)
            };

            return products;
        }
    }

    abstract class Person
    {
        protected int Money = 9000;
        protected List<Product> Products = new List<Product>();

        public int ProductCount => Products.Count;

        public void ShowInfo()
        {
            if (ProductCount > 0)
            {
                int index = 1;

                foreach (Product product in Products)
                {
                    Console.WriteLine($"|Номер: {index}|Название : {product.Name}|Цена : {product.Price}|");
                    index++;
                }
            }
            else
            {
                Console.WriteLine("сумка пуста");
            }
        }
    }

    class Player : Person
    {
        public void Buy(Product product)
        {
            Money -= product.Price;
            Products.Add(product);
        }

        public bool CanPay(int price)
        {
            return Money >= price;
        }
    }

    class Salesperson : Person
    {
        public Salesperson(List<Product> products)
        {
            Products = products;
        }

        public bool TryGetProduct(out Product product)
        {
            Console.WriteLine("Введите номер товара ");
            int.TryParse(Console.ReadLine(), out int number);

            if (number > 0 && number <= ProductCount)
            {
                product = Products[number - 1];
                return true;
            }
            else
            {
                Console.WriteLine("такого продукта нет ");
                product = null;
                return false;
            }
        }

        public void Sell(Product product)
        {
            Money += product.Price;
            Products.Remove(product);
        }
    }
}


