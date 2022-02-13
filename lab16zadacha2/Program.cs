using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace lab16zadacha2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../../Products.json");
            string jsonstring1 = sr.ReadToEnd();

            Product[] product1 = JsonSerializer.Deserialize<Product[]>(jsonstring1);
            Console.WriteLine(jsonstring1);
            Product maxPrice = product1[0];
            foreach (Product p in product1)
            {
                if (p.Price > maxPrice.Price)
                {
                    maxPrice = p;
                }
            }
            Console.WriteLine($"Самый дорогой из товаров - код: {maxPrice.Code}, название: {maxPrice.Name}, цена: {maxPrice.Price}");
            Console.ReadKey();
        }
    }
    class Product
    {
        int code;
        [JsonPropertyName("Код товара")]
        public int Code
        {
            set
            {
                if (value > 0)
                {
                    code = value;
                }
                else
                {
                    Console.WriteLine("Код не может иметь отрицательное значение");
                }
            }
            get
            {
                return code;
            }

        }
        [JsonPropertyName("Название товара")]
        public string Name { get; set; }
        double price;
        [JsonPropertyName("Цена товара")]
        public double Price
        {
            set
            {
                if (value > 0)
                {
                    price = value;
                }
                else
                {
                    Console.WriteLine("Цена не может иметь отрицательное значение");
                }
            }
            get
            {
                return price;
            }
        }
    }
}