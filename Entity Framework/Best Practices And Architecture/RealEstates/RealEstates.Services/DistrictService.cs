using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly RealEstateDbContext context;
        public DistrictService(RealEstateDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DistrictViewModel> GetTopDistrictsByAveragePrice(int count)
        {
            return this.context.Districts
                .Select(d => new DistrictViewModel
                {
                    AveragePrice = d.Properties.Average(p => p.Price),
                    MaxPrice = d.Properties.Max(p => p.Price),
                    MinPrice = d.Properties.Min(p => p.Price),
                    Name = d.Name,
                    PropertiesCount = d.Properties.Count()
                })
                .OrderBy(d => d.AveragePrice)
                .Take(count)
                .ToList();
        }



        public IEnumerable<DistrictViewModel> GetTopDistrictsByNumberOfProperties(int count)
        {
            return this.context.Districts
                .Select(d => MapToDistrictViewModel(d))
                .OrderByDescending(d => d.PropertiesCount)
                .Take(count)
                .ToList();


        }
        private static DistrictViewModel MapToDistrictViewModel(District d)
        {
            return new DistrictViewModel
            {
                AveragePrice = d.Properties.Average(p => p.Price),
                MaxPrice = d.Properties.Max(p => p.Price),
                MinPrice = d.Properties.Min(p => p.Price),
                Name = d.Name,
                PropertiesCount = d.Properties.Count()
            };
        }
    }
}
