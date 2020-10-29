using System.Collections.Generic;

namespace PoSLibrary.Model
{
    public class Product
    {
        public string Code { get; set; }
        public double BasePrice { get; set; }
        public ExtendedPrice ExtendedPrice { get; set; }
    }
}
