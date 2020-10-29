namespace PoSLibrary
{
    using System;
    using Bucket;
    using Bucket.ExtPricesBucketWithReplace;

    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        public PointOfSaleTerminal()
        {
            this.BucketHandler = new ExtPriceWithReplaceHandler();
        }

        public IBucketHandler BucketHandler { get; set; }

        private Model.PriceList Prices { get; set; }

        public void SetBucketHandler(IBucketHandler bucketHandler)
        {
            this.BucketHandler = bucketHandler;
        }

        public double CalculateTotal()
        {
            return this.BucketHandler.CalculateTotal();
        }

        public void SetPricing(Model.PriceList list)
        {
            this.Prices = list;
        }

        public void Scan(string productCode)
        {
            this.BucketHandler.Scan(productCode, this.Prices);
        }

        public void PrintBucket()
        {
            Console.WriteLine("Bucket:");
            foreach (var item in this.BucketHandler.GetBucket())
            {
                Console.WriteLine($"\t{item.Code}: {item.Price} ({item.Status})");
            }
        }
    }
}
