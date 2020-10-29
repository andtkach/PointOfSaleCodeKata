namespace PoSTests.Simple
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PoSLibrary;
    using PoSLibrary.Bucket.SimpleBucket;
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
        public void VerifyTotalPrice_Simple_ABCD()
        {
            this.terminal = new PointOfSaleTerminal();
            this.terminal.SetBucketHandler(new SimpleHandler());

            this.terminal.SetPricing(this.priceList.GetPriceList());

            this.terminal.Scan("A");
            this.terminal.Scan("B");
            this.terminal.Scan("C");
            this.terminal.Scan("D");

            double result = this.terminal.CalculateTotal();

            Assert.IsTrue(Math.Abs(result - 7.25) < this.tolerance);
        }

        [TestMethod]
        public void VerifyTotalPrice_Simple_CCCCCCC()
        {
            this.terminal = new PointOfSaleTerminal();
            this.terminal.SetBucketHandler(new SimpleHandler());

            this.terminal.SetPricing(this.priceList.GetPriceList());

            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");
            this.terminal.Scan("C");

            double result = this.terminal.CalculateTotal();

            Assert.IsTrue(Math.Abs(result - 7.0) < this.tolerance);
        }

        [TestMethod]
        public void VerifyTotalPrice_Simple_ABCDABA()
        {
            this.terminal = new PointOfSaleTerminal();
            this.terminal.SetBucketHandler(new SimpleHandler());

            this.terminal.SetPricing(this.priceList.GetPriceList());

            this.terminal.Scan("A");
            this.terminal.Scan("B");
            this.terminal.Scan("C");
            this.terminal.Scan("D");
            this.terminal.Scan("A");
            this.terminal.Scan("B");
            this.terminal.Scan("A");

            double result = this.terminal.CalculateTotal();

            Assert.IsTrue(Math.Abs(result - 14) < this.tolerance);
        }

        [TestMethod]
        public void VerifyTotalPrice_Simple_DiscountNotApplied()
        {
            this.terminal = new PointOfSaleTerminal();
            this.terminal.SetBucketHandler(new SimpleHandler());

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

            Assert.IsTrue(Math.Abs(result - 13.0) < this.tolerance);
        }
    }
}
