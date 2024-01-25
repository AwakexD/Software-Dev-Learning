using Trucks.Data.Models;
using Trucks.Data.Models.Enums;
using Trucks.DataProcessor.ExportDto;
using Trucks.DataProcessor.ImportDto;

namespace Trucks
{
    using AutoMapper;

    public class TrucksProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TrucksProfile()
        {
            // Import Configurations
            CreateMap<DespatcherTruckImportDto, Truck>()
                .ForMember(d => d.CategoryType, 
                    opt => opt.MapFrom(x => (CategoryType)x.CategoryType))
                .ForMember(d => d.MakeType,
                    opt => opt.MapFrom(x => (MakeType)x.MakeType));
            
            CreateMap<DespatcherImportDto, Despatcher>()
                .ForMember(d => d.Trucks, otp => otp.Ignore());

            CreateMap<ClientImportDto, Client>()
                .ForMember(c => c.ClientsTrucks, otp => otp.Ignore());

            // Export Configurations
            CreateMap<Truck, ExportTruckDto>()
                .ForMember(d => d.Make, otp => otp.MapFrom(x => Enum.GetName(x.MakeType)));

            CreateMap<Despatcher, ExportDespatchersAndTrucksDto>()
                .ForMember(d => d.TrucksCount, otp => otp.MapFrom(d => d.Trucks.Count()))
                .ForMember(d => d.Trucks,
                    otp => otp.MapFrom(d => d.Trucks.OrderByDescending(x => x.RegistrationNumber)));
        }
    }
}
