using System.Text;
using Medicines.Data.Models;
using Medicines.DataProcessor.ImportDtos;


namespace Medicines.DataProcessor
{
    using AutoMapper;
    using Medicines.Data;
    using Medicines.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    public class Deserializer
    {
        // ToDo : Data import into the database 
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";


        public static string ImportPatients(MedicinesContext context, string jsonString) // Json Import
        {
            int counter = 0;
            StringBuilder sb = new StringBuilder();
            var mapper = CreateMapper();

            IEnumerable<PatientImportDto> patientsDto = JsonConvert.DeserializeObject<IEnumerable<PatientImportDto>>(jsonString);

            ICollection<Patient> patients = new List<Patient>();

            foreach (var patientDto in patientsDto)
            {
                if (!IsValid(patientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient patient = mapper.Map<Patient>(patientDto);

                foreach (var meidcineId in patientDto.Medicines)
                {
                    if (patient.PatientMedicines.Any(x => x.MedicineId == meidcineId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine patientMedicine = new PatientMedicine()
                    {
                        Patient = patient,
                        MedicineId = meidcineId
                    };

                    patient.PatientMedicines.Add(patientMedicine);
                }

                counter += patient.PatientMedicines.Count();
                patients.Add(patient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientMedicines.Count));
            }

            context.AddRange(patients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();

            int medCounter = 0;

            ImportPharmacyDto[] pharmacyDtos = xmlHelper.Deserialize<ImportPharmacyDto[]>(xmlString, "Pharmacies");

            ICollection<Pharmacy> validPharmacies = new List<Pharmacy>();

            foreach (var phDto in pharmacyDtos)
            {
                if (!IsValid(phDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy pharmacy = new Pharmacy()
                {
                    Name = phDto.Name,
                    PhoneNumber = phDto.PhoneNumber,
                    IsNonStop = bool.Parse(phDto.IsNonStop),
                };

                foreach (var medDto in phDto.Medicines)
                {
                    if (!IsValid(medDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime medicineProductionDate;
                    bool isProductionDateValid = DateTime
                        .TryParseExact(medDto.ProductionDate, "yyyy-MM-dd", CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out medicineProductionDate);

                    if (!isProductionDateValid)
                    {
                        sb.Append(ErrorMessage);
                        continue;
                    }

                    DateTime medicineExpityDate;
                    bool isExpityDateValid = DateTime
                        .TryParseExact(medDto.ExpiryDate, "yyyy-MM-dd", CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out medicineExpityDate);

                    if (!isExpityDateValid)
                    {
                        sb.Append(ErrorMessage);
                        continue;
                    }

                    if (medicineProductionDate >= medicineExpityDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (pharmacy.Medicines.Any(x => x.Name == medDto.Name && x.Producer == medDto.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Medicine medicine = new Medicine()
                    {
                        Name = medDto.Name,
                        Price = (decimal)medDto.Price,
                        Category = (Category)medDto.Category,
                        ProductionDate = medicineProductionDate,
                        ExpiryDate = medicineExpityDate,
                        Producer = medDto.Producer,
                    };

                    medCounter++;

                    pharmacy.Medicines.Add(medicine);
                }

                validPharmacies.Add(pharmacy);
                sb.AppendLine(string
                    .Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }
            context.Pharmacies.AddRange(validPharmacies);
            context.SaveChanges();
            return sb.ToString().TrimEnd();


        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static IMapper CreateMapper() => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MedicinesProfile>();
        }));
    }
}
