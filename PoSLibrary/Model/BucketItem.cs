namespace PoSLibrary.Model
{
    using Bucket;

    public class BucketItem
    {
        public string Code { get; set; }

        public double Price { get; set; }
        
        public BucketItemStatus Status { get; set; }
    }
}