using System.ComponentModel.DataAnnotations;
using Medicines.Data.Models.Enums;

namespace Medicines.DataProcessor.ImportDtos
{
    public class PatientImportDto
    {
        [StringLength(100, MinimumLength = 5)]
        public string FullName { get; set; }

        public AgeGroup AgeGroup { get; set; }

        public Gender Gender { get; set; }

        public int[] Medicines { get; set; }
    }
}
