using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Trucks.DataProcessor.ExportDto;
using Trucks.Utilities;

namespace Trucks.DataProcessor
{
    using Data;
    
    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var despatchersDto = context.Despatchers
                .Where(d => d.Trucks.Count() >= 1)
                .ProjectTo<ExportDespatchersAndTrucksDto>(mapper.ConfigurationProvider)
                .OrderByDescending(x => x.Trucks.Length)
                .ThenBy(x => x.Name)
                .ToList();

            return xmlHelper.Serialize(despatchersDto, "Despatchers");
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .Include(c => c.ClientsTrucks)
                .ThenInclude(c => c.Truck)
                .Where(c => c.ClientsTrucks.Any(t => t.Truck.TankCapacity >= capacity))
                .AsNoTracking()
                .ToArray()
                .Select(c => new
                {
                    c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(t => t.Truck.TankCapacity >= capacity)
                        .Select(t => new
                        {
                            TruckRegistrationNumber = t.Truck.RegistrationNumber,
                            t.Truck.VinNumber,
                            t.Truck.TankCapacity,
                            t.Truck.CargoCapacity,
                            CategoryType = Enum.GetName(t.Truck.CategoryType),
                            MakeType = Enum.GetName(t.Truck.MakeType)
                        })
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                        .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }

        public static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<TrucksProfile>()));
        }
    }
}
