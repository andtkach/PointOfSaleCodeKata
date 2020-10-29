using PoSLibrary.Bucket.ExtPricesBucketWithDivide;

namespace PoSConsole
{
    using System;
    using PoSLibrary;
    using PoSLibrary.PriceList;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter product codes and press Enter (ABCD)");
            
            var products = Console.ReadLine();

            var terminal = new PointOfSaleTerminal();
            ////terminal.SetBucketHandler(new SimpleHandler());
            ////terminal.SetBucketHandler(new ExtPriceWithReplaceHandler());
            ////terminal.SetBucketHandler(new ExtPriceWithDivideHandler());
            
            var priceList = new TestPriceListGenerator();

            terminal.SetPricing(priceList.GetPriceList());

            if (products != null)
            {
                var codes = products.ToUpper().ToCharArray();
                foreach (var code in codes)
                {
                    terminal.Scan(code.ToString());
                }
            }

            double result = terminal.CalculateTotal();

            Console.WriteLine($"Total: {result}");
            terminal.PrintBucket();
        }
    }
}
