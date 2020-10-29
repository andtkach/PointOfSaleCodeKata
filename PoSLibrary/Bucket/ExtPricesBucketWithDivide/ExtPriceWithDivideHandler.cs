namespace PoSLibrary.Bucket.ExtPricesBucketWithDivide
{
    using System;
    using System.Linq;
    using Model;

    public class ExtPriceWithDivideHandler : BucketHandler
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
            
            if (product.ExtendedPrice != null)
            {
                if (this.CanApplyExtendedPrice(product))
                {
                    this.ApplyExtendedPrice(product);
                }
                else
                {
                    this.AddProductToBucket(product);
                }
            }
            else
            {
                this.AddProductToBucket(product);
            }
        }

        private void AddProductToBucket(Product product)
        {
            var newItem = new BucketItem
            {
                Status = BucketItemStatus.Added,
                Price = product.BasePrice,
                Code = product.Code
            };

            this.Bucket.Add(newItem);
        }

        private void ApplyExtendedPrice(Product product)
        {
            this.AddProductToBucket(product);

            var newPrice = product.ExtendedPrice.Price / product.ExtendedPrice.Amount; 
            
            var productsToUpdate = this.Bucket.Where(p =>
                p.Code.Equals(product.Code, StringComparison.CurrentCultureIgnoreCase) &&
                p.Status == BucketItemStatus.Added).ToList();

            foreach (var item in productsToUpdate)
            {
                item.Status = BucketItemStatus.Updated;
                item.Price = newPrice;
            }
        }

        private bool CanApplyExtendedPrice(Product product)
        {
            if (this.Bucket == null || product.ExtendedPrice == null)
            {
                return false;
            }

            return this.Bucket
                .Count(p => p.Code.Equals(product.Code) 
                            && p.Status != BucketItemStatus.Updated) >= product.ExtendedPrice.Amount - 1;
        }
    }
}
