using System;
using System.IO;

namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] productsFromFile;

            try {
                productsFromFile = File.ReadAllLines("products.csv");
            } catch (Exception) {
                return;
            }

            if (productsFromFile.Length == 0) {
                return;
            }

            var productsArray = new Product[productsFromFile.Length];

            for (var i = 0; i < productsFromFile.Length; i++) {
                var isDuplicate = false;
                var values = productsFromFile[i].Split(';');

                foreach (var p in productsArray) {
                    if (p != null && p.ProductId.Equals(values[0])) {
                        isDuplicate = true;
                    }
                }

                if (!isDuplicate) {
                    var product = new Product()
                    {
                        ProductId = values[0],
                        Name = values[1],
                        Description = values[2],
                        Price = GetRandomPrice()
                    };

                    productsArray[i] = product;
                }
            }

            foreach(var p in productsArray) {
                if (p != null) {
                    Console.WriteLine($"{p.ProductId} {p.Name} {p.Price}");
                }
            }
        }

        public static decimal GetRandomPrice()
        {
            var random = new Random();
            var randomNumber = random.NextDouble() * 100;
            var roundedNumber = Math.Round(randomNumber, 2);

            return (decimal)roundedNumber;
        }
    }
}
