using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;

namespace lab16zadacha
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Product[] product = new Product[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара");
                int code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара");
                string name = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                double price = Convert.ToDouble(Console.ReadLine());
                product[i] = new Product() { Code = code, Name = name, Price = price };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(product, options);
            using (StreamWriter sw = new StreamWriter("../../../Products.json")) {sw.Write(jsonString);}
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
