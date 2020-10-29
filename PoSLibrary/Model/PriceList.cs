namespace PoSLibrary.Model
{
    using System.Collections.Generic;

    public class PriceList
    {
        public PriceList()
        {
            this.Prices = new List<Product>();
        }

        public List<Product> Prices { get; set; }
    }
}
