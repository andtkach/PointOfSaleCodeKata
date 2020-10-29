namespace PoSLibrary.PriceList
{
    using Model;

    public class TestPriceListGenerator : IPriceListGenerator
    {
        public Model.PriceList GetPriceList()
        {
            var list = new Model.PriceList();

            var productA = new Product
            {
                Code = "A",
                BasePrice = 1.25,
                ExtendedPrice = new ExtendedPrice { Amount = 3, Price = 3.0, Description = "3 for $3.00" }
            };

            list.Prices.Add(productA);

            list.Prices.Add(new Product
            {
                Code = "B",
                BasePrice = 4.25
            });

            var productC = new Product
            {
                Code = "C",
                BasePrice = 1,
                ExtendedPrice = new ExtendedPrice { Price = 5.0, Amount = 6, Description = "$5 for a six pack" }
            };
            
            list.Prices.Add(productC);

            list.Prices.Add(new Product
            {
                Code = "D",
                BasePrice = 0.75
            });

            return list;
        }
    }
}
