using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using AutoMapper;
using System.Text;
using Newtonsoft.Json;
using Trucks.Data.Models;
using Trucks.DataProcessor.ImportDto;
using Trucks.Utilities;

namespace Trucks.DataProcessor
{
    using Data;
    using System.ComponentModel.DataAnnotations;


    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();

            IEnumerable<DespatcherImportDto> despatcherImportDtos =
                xmlHelper.DeserializeCollection<DespatcherImportDto>(xmlString, "Despatchers").ToList();

            HashSet<Despatcher> validDespatchers = new HashSet<Despatcher>();

            foreach (var despatcherDto in despatcherImportDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher mappedDespatcher = mapper.Map<Despatcher>(despatcherDto);


                foreach (var truck in despatcherDto.Trucks)
                {
                    if (!IsValid(truck))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck mappedTruck = mapper.Map<Truck>(truck);
                    mappedDespatcher.Trucks.Add(mappedTruck);
                }

                validDespatchers.Add(mappedDespatcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, mappedDespatcher.Name, mappedDespatcher.Trucks.Count()));
            }

            context.AddRange(validDespatchers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            IMapper mapper = CreateMapper();
            StringBuilder sb = new StringBuilder();
            ICollection<int> allTrucksInDb = context.Trucks.Select(x => x.Id).ToArray();
            
            IEnumerable<ClientImportDto> clientDtos = JsonConvert.DeserializeObject<IEnumerable<ClientImportDto>>(jsonString);

            ICollection<Client> validClients = new HashSet<Client>();

            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto) || clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue; 
                }

                Client mappedClient = mapper.Map<Client>(clientDto);

                foreach (var truck in clientDto.Trucks.Distinct())
                {
                    if (!allTrucksInDb.Contains(truck))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ClientTruck newCt = new ClientTruck
                    {
                        Client = mappedClient,
                        TruckId = truck
                    };

                    mappedClient.ClientsTrucks.Add(newCt);
                }

                validClients.Add(mappedClient);

                sb.AppendLine(string.Format(SuccessfullyImportedClient, mappedClient.Name,
                    mappedClient.ClientsTrucks.Count()));
            }

            context.AddRange(validClients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<TrucksProfile>()));
        }
    }
}