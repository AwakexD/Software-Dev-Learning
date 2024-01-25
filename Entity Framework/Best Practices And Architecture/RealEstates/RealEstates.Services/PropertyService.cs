using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public class PropertyService : IPropertiesService
    {
        private readonly RealEstateDbContext context;

        public PropertyService(RealEstateDbContext context)
        {
            this.context = context; 
        }

        public void Create(int size, int? floor, int? maxFloors, string district, string propertyType, string buildingType, int? year,
            int price)
        {
            if (district == null)
            {
                return;
            }

            var property = new RealEstateProperty
            {
                Size = size,
                Price = price,
                Year = year,
                Floor = floor,
                TotalNumberOfFloors = maxFloors,
            };

            if (year < 1800)
            {
                property.Year = null;
            }

            if (floor <= 0)
            {
                property.Floor = null;
            }

            if (maxFloors <= 0)
            {   
                property.TotalNumberOfFloors = null;
            }

            //District Check
            var districtEntity = 
                this.context.Districts.FirstOrDefault(x => x.Name.Trim() == district.Trim());
            if (districtEntity == null)
            {
                districtEntity = new District { Name = district };
            }
            property.District = districtEntity;


            //BuildingType Check
            var buildingTypeEntity =
                this.context.BuildingType.FirstOrDefault(x => x.Name.Trim() == buildingType.Trim());
            if (buildingTypeEntity == null)
            {
                buildingTypeEntity = new BuildingType { Name = buildingType };
            }
            property.BuildingType = buildingTypeEntity;


            //PropertyType Check
            var propertyTypeEntity =
                this.context.PropertyTypes.FirstOrDefault(x => x.Name.Trim() == propertyType.Trim());
            if (propertyTypeEntity == null)
            {
                propertyTypeEntity = new PropertyType { Name = propertyType };
            }
            property.PropertyType = propertyTypeEntity;

            this.context.RealEstateProperties.Add(property);
            this.context.SaveChanges();

            //this.UpdateTags(property.Id);
        }


        public IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize)
        {
            return this.context.RealEstateProperties
                .Where(x => x.Year >= minYear && x.Year <= maxYear && x.Size >= minSize && x.Size <= maxSize)
                .Select(x => MapToPropertyViewModel(x))
                .OrderBy(x => x.Price)
                .ToList();
        }

        public IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice)
        {
            return this.context.RealEstateProperties
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .Select(x => MapToPropertyViewModel(x))
                .OrderBy(x => x.Price)
                .ToList();
        }

        private static PropertyViewModel MapToPropertyViewModel(RealEstateProperty x)
        {
            return new PropertyViewModel
            {
                Price = x.Price,
                Floor = (x.Floor ?? 0) + "/" + (x.TotalNumberOfFloors),
                Size = x.Size,
                Year = x.Year ?? 0,
                BuildingType = x.BuildingType.Name,
                District = x.District.Name,
                PropertyType = x.PropertyType.Name
            };
        }

    }
}
