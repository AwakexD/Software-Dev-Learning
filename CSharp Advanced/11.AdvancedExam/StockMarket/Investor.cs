using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> Portfolio;

        public string FullName { get; set; }
        public string EmailAddres { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public Investor()
        {
            Portfolio = new List<Stock>();
        }

        public Investor(string fn, string email, decimal money, string brokerName) : this()
        {
            this.FullName = fn;
            this.EmailAddres = email;
            this.MoneyToInvest = money;
            this.BrokerName = brokerName;
        }

        private Stock FindStock(string companyName) => Portfolio.FirstOrDefault(x => x.CompanyName == companyName);

        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCap > 10000 && this.MoneyToInvest > stock.PricePerShare)
            {
                Portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (Portfolio.Any(x => x.CompanyName == companyName))
            {
                Stock stockToSell = FindStock(companyName);

                if (sellPrice < stockToSell.PricePerShare)
                {
                    return ($"Cannot sell {stockToSell.CompanyName}.");
                }
                else
                {
                    Portfolio.Remove(stockToSell);
                    MoneyToInvest += sellPrice;

                    return $"{stockToSell.CompanyName} was sold.";
                }
            }
            else
            {
                return ($"{companyName} does not exist.");
            }
        }

        public Stock FindBiggestCompany()
        {
            if (Count < 1)
            {
                return null;
            }

            Stock BiggestCompany = Portfolio[0];
            foreach (Stock stock in Portfolio)
            {
                if (stock.MarketCap > BiggestCompany.MarketCap)
                {
                    BiggestCompany = stock;
                }
            }

            return BiggestCompany;
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            sb.Append(string.Join('\n', this.Portfolio));

            return sb.ToString().TrimEnd();
        }
    }
}
