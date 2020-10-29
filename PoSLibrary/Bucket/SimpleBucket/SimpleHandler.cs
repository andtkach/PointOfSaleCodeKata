namespace PoSLibrary.Bucket.SimpleBucket
{
    using System.Linq;
    using Model;

    public class SimpleHandler : BucketHandler
    {
        public override double CalculateTotal()
        {
            return this.Bucket.Sum(item => item.Price);
        }

        public override void Scan(string productCode, Model.PriceList prices)
        {
            var product = this.GetProductByCode(productCode, prices);

            if (product == null)
            {
                return;
            }
            
            var newItem = new BucketItem
            {
                Status = BucketItemStatus.Added,
                Price = product.BasePrice,
                Code = product.Code
            };

            this.Bucket.Add(newItem);
        }
    }
}
