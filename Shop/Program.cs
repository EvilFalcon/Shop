using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Shop _shop = new Shop();
            Player _player = new Player();

            _shop.Work(_player);
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

        public void PriceChange(int price)
        {
            int newPrice = price / 2;
            Price = newPrice;

        }

        public void ShowInfo()
        {
            Console.WriteLine($" название товара: {Name}, стоимость товара : {Price} ");
        }
    }

    class Shop
    {
        Salesperson _salesperson = new Salesperson();

        private List<Product> _products = new List<Product>();

        public Shop()
        {
            CreateProduct(_salesperson);
        }

        public void Work(Player player)
        {
            const string CommandBuyItem = "1";
            const string CommandLookInventory = "2";
            const string CommandExitProgram = "3";

            bool isWork = true;

            while (isWork)
            {


                switch (Console.ReadLine())
                {
                    case CommandBuyItem:

                        break;

                    case CommandLookInventory:

                        break;

                    case CommandExitProgram:
                        isWork = false;
                        break;
                }
            }
        }

        private void TryGetP()
        {
            Console.WriteLine();

        }

        private int ReadInt()
        {
            int number;

            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.WriteLine("ошибка ввода");
            }

            return number;
        }

        private void CreateProduct(Person person)
        {
            List<string> name = new List<string>() { "меч", "щит", "кожаный доспех", "кольчуга", "латы", "кожаный шлем", "латный шлем", "кожаные перчатки", "латные перчатки" };
            List<int> price = new List<int>() { 500, 250, 100, 500, 1000, 50, 400, 40, 350 };

            for (int i = 0; i < name.Count; i++)
            {
                Product product = new Product(name[i], price[i]);
                person.TakeItem(product);
            }
        }
    }

    abstract class Person
    {
        private int _money = 9000;
        private List<Product> _products = new List<Product>();

        public int Money => _money;

        public int  ProductCount => _products.Count;

        public void ShowInfo()
        {
            Console.WriteLine($"У продавца {_money} золота");
        }

        public void GetMoney(int price)
        {
            _money += price;
        }

        public void GetItem(Product product, int price)
        {
            _money -= price;
            product.PriceChange(product.Price);
            _products.Add(product);
        }

        private Product GiveItem(int item)
        {
            if (_products.Count > 0)
            {
                Product product = _products[item];
                _products.Remove(product);
                return product;
            }
            else
            {
                Console.WriteLine("У продавца  нет предметов для продажи");
            }

            return null;
        }

        public void TakeItem(Product product)
        {
            _products.Add(product);
        }

        public void LookInventory()
        {
            if (_products.Count > 0)
            {
                foreach (Product product in _products)
                {
                    product.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("Ваш инвентарь пуст");
            }
        }
    }

    class Player : Person
    {

    }

    class Salesperson : Person
    {
       

        public bool TryGetProduct(Product product)
        {
            Console.WriteLine("Введите номер товара ");
            int.TryParse(Console.ReadLine(), out int number);

            if (number>0&&number<=ProductCount)
        }
       
    }
}


