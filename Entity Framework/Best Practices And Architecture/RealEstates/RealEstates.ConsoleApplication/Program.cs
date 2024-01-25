using System.Text;
using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;

namespace RealEstates.ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            RealEstateDbContext db = new RealEstateDbContext();

            IPropertiesService propertiesService = new PropertyService(db);
            IDistrictService districtService = new DistrictService(db);
            //propertiesService.Create(80, 2, 3, "Люлин", "Apartment", "Panel", 1980, 30000);

            var districts = districtService.GetTopDistrictsByAveragePrice(5);

            foreach (var district in districts)
            {
                Console.WriteLine($"District name - {district.Name}\n" +
                                  $"Average price - \u20ac{district.AveragePrice}\n" +
                                  $"Max price - \u20ac{district.MaxPrice} | Min price - \u20ac{district.MinPrice}\n" +
                                  $"Properties count - {district.PropertiesCount}\n");
            }
        }
    }
}