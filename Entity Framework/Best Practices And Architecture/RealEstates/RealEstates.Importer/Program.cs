using System.Text.Json;
using RealEstates.Data;
using RealEstates.Services;

namespace RealEstates.Importer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText("imot.bg-raw-data-2021-03-18.json");

            var properties = JsonSerializer.Deserialize<IEnumerable<JsonProperty>>(json);
            var db = new RealEstateDbContext();
            IPropertiesService propertiesService = new PropertyService(db);

            foreach (var property in properties.Where(x => x.Price > 1000))
            {
                propertiesService.Create(property.Size,
                    property.Floor,
                    property.TotalFloors,
                    property.District,
                    property.Type,
                    property.BuildingType,
                    property.Year,
                    property.Price);
            }
        }
    }

}
