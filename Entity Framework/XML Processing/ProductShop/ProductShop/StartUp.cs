using System.Xml;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext db = new ProductShopContext();

            db.Database.EnsureCreated();

            //Console.WriteLine(File.ReadAllText("../../../Datasets/users.xml"));

            Console.WriteLine(ImportUsers(db, "../../../Datasets/users.xml"));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto), new XmlRootAttribute("Users"));

            var usersResult = (ImportUserDto[])xmlSerializer.Deserialize(File.OpenRead(inputXml));

            return null;
        }
    }
}