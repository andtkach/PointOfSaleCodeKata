namespace PoSLibrary
{
    using Bucket;

    public interface IPointOfSaleTerminal
    {
        double CalculateTotal();

        void SetPricing(Model.PriceList list);

        void Scan(string productCode);

        void PrintBucket();

        void SetBucketHandler(IBucketHandler bucketHandler);
    }
}