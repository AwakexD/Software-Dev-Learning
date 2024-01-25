using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare{ get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCap { get; set; }

        public Stock(string cn, string director, decimal pps, int tnos)
        {
            this.CompanyName = cn;
            this.Director = director;
            this.PricePerShare = pps;
            this.TotalNumberOfShares = tnos;

            this.MarketCap = PricePerShare * TotalNumberOfShares;
        }

        public override string ToString()
        {
            return $"Company: {CompanyName}\nDirector: {Director}\nPrice per share: ${PricePerShare}\nMarket capitalization: ${MarketCap}";
        }
    }
}
