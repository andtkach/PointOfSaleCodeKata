namespace PoSTests.Divide
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PoSLibrary;
    using PoSLibrary.Bucket.ExtPricesBucketWithDivide;
    using PoSLibrary.PriceList;

    [TestClass]
    public class PointOfSaleTerminalTests
    {
        private readonly double tolerance = 0.000000001;
        private readonly IPriceListGenerator priceList;
        private IPointOfSaleTerminal terminal;

        public PointOfSaleTerminalTests()
        {
            this.priceList = new TestPriceListGenerator();
        }

        [TestMethod]
        public void VerifyTotalPrice_ExtPriceWithDivide_ABCD()
        {
            this.terminal = new PointOfSaleTerminal();
            this.terminal.SetBucketHandler(new ExtPriceWithDivideHandler());

            this.terminal.SetPricing(this.priceList.GetPriceList());

            this.terminal.Scan("A");
            this.terminal.Scan("B");
            this.terminal.Scan("C");
            this.terminal.Scan("D");

            double result = this.terminal.CalculateTotal();
            
            Assert.IsTrue(Math.Abs(result - 7.25) < this.tolerance);
        }

        [TestMethod]
        public void VerifyTotalPrice_ExtPriceWithDivide_CCCCCCC()
        {
            this.terminal = new PointOfSaleTerminal();
            this.terminal.SetBucketHandler(new ExtPriceWithDivideHandler());

            this.terminal.SetPricing(this.priceList.GetPriceList());

            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");

            double result = this.terminal.CalculateTotal();

            Assert.IsTrue(Math.Abs(result - 6.0) < this.tolerance);
        }

        [TestMethod]
        public void VerifyTotalPrice_ExtPriceWithDivide_ABCDABA()
        {
            this.terminal = new PointOfSaleTerminal();
            this.terminal.SetBucketHandler(new ExtPriceWithDivideHandler());

            this.terminal.SetPricing(this.priceList.GetPriceList());

            this.terminal.Scan("A");
            this.terminal.Scan("B");
            this.terminal.Scan("C");
            this.terminal.Scan("D");
            this.terminal.Scan("A");
            this.terminal.Scan("B");
            this.terminal.Scan("A");

            double result = this.terminal.CalculateTotal();

            Assert.IsTrue(Math.Abs(result - 13.25) < this.tolerance);
        }

        [TestMethod]
        public void VerifyTotalPrice_Simple_DiscountAppliedOnce()
        {
            this.terminal = new PointOfSaleTerminal();
            this.terminal.SetBucketHandler(new ExtPriceWithDivideHandler());

            this.terminal.SetPricing(this.priceList.GetPriceList());

            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");

            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");

            this.terminal.Scan("C");

            double result = this.terminal.CalculateTotal();

            Assert.IsTrue(Math.Abs(result - 11.0) < this.tolerance);
        }
    }
}
