namespace PoSLibrary.Bucket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public abstract class BucketHandler : IBucketHandler
    {
        protected BucketHandler()
        {
            this.Bucket = new List<BucketItem>();
        }

        protected List<BucketItem> Bucket { get; set; }

        public abstract double CalculateTotal();

        public abstract void Scan(string productCode, Model.PriceList prices);

        public virtual IEnumerable<BucketItem> GetBucket()
        {
            return this.Bucket;
        }

        protected Product GetProductByCode(string productCode, Model.PriceList prices)
        {
            return prices.Prices.FirstOrDefault(p =>
                p.Code.Equals(productCode, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
