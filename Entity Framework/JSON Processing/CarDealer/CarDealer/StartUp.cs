using AutoMapper;
using AutoMapper.Execution;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static readonly IMapper mapper = CreateMaper();
        public static void Main()
        {
            CarDealerContext db = new CarDealerContext();

            //db.Database.EnsureCreated();

            Console.WriteLine(ImportCars(db, File.ReadAllText("../../../Datasets/cars.json")));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            ImportSupplierDto[] suppliersDto = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);

            HashSet<Supplier> suppliers = new HashSet<Supplier>();

            foreach (var newSup in suppliersDto)
            {
                var mapped = mapper.Map<Supplier>(newSup);
                suppliers.Add(mapped); 
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            ImportPartDto[] importPartsDto = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

            HashSet<Part> newParts = new HashSet<Part>();

            foreach (var dtoPart in importPartsDto)
            {
                var searchSupplier = context.Suppliers.Any(s => s.Id == dtoPart.SupplierId);

                if (searchSupplier)
                {
                    var mapped = mapper.Map<Part>(dtoPart);
                    newParts.Add(mapped);
                }
            }

            context.Parts.AddRange(newParts);
            context.SaveChanges();

            return $"Successfully imported {newParts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ImportCarDto[] newCars = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson)!;

            ICollection<PartCar> partsCars = new HashSet<PartCar>();
            int importedCars = 0;

            foreach (var newCar in newCars)
            {
                var mappedCar = mapper.Map<Car>(newCar);
                context.Cars.Add(mappedCar);
                context.SaveChanges();
                importedCars++;

                foreach (var partId in newCar.CarParts)
                {
                    if (!context.Parts.Any(p => p.Id == partId))
                    {
                        continue;
                    }

                    var partCar = new PartCar
                    {
                        CarId = mappedCar.Id,
                        PartId = partId
                    };

                    partsCars.Add(partCar);
                }
            }

            context.PartsCars.AddRange(partsCars);
            context.SaveChanges();

            return $"Successfully imported {importedCars}.";
        }

        public static IMapper CreateMaper()
        {
            return new Mapper(new MapperConfiguration(config =>
            {
                config.AddProfile<CarDealerProfile>();
            }));
        }
    }
}