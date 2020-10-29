namespace PoSLibrary.Bucket
{
    using System.Collections.Generic;
    using Model;

    public interface IBucketHandler
    {
        double CalculateTotal();

        void Scan(string productCode, PriceList prices);

        IEnumerable<BucketItem> GetBucket();
    }
}
