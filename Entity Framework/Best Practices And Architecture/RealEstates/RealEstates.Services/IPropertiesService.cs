using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public interface IPropertiesService
    {
        void Create(int size, int? floor, int? maxFloors, string district, string propertyType, string buildingType, int? year, int price);

        IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize);

        IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice);
    }
}
