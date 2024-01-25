using System.Reflection.Metadata;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext db = new ProductShopContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //Console.WriteLine(ImportUsers(db, File.ReadAllText("../../../Datasets/users.json")));
            //Console.WriteLine(ImportProducts(db, File.ReadAllText("../../../Datasets/products.json")));
            //Console.WriteLine(ImportCategories(db, File.ReadAllText("../../../Datasets/categories.json")));
            // Console.WriteLine(ImportCategoryProducts(db, File.ReadAllText("../../../Datasets/categories-products.json")));

            Console.WriteLine(GetUsersWithProducts(db));

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
           User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Succesfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            
            Category[] categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();


            return $"Succesfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProduct[] categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Succesfully imported {categoryProducts.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                }).ToArray();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(u => u.ProductsSold.Any(b => b.BuyerId != null))
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .Select(user => new
                {
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    soldProducts = user.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName,
                        })
                });

            string json = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count(),
                    averagePrice = $"{c.CategoriesProducts.Average(cp => cp.Product.Price):f2}",
                    totalRevenue = $"{c.CategoriesProducts.Sum(cp => cp.Product.Price):f2}"
                })
                .OrderByDescending(x => x.productsCount);

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Where(p => p.BuyerId != null).Count(),
                        products = u.ProductsSold
                            .Where(p => p.BuyerId != null)
                            .Select(p => new 
                            {
                                name = p.Name,
                                price = $"{p.Price:f2}"
                            })
                    }
                }).OrderByDescending(u => u.soldProducts.count);

            var resObj = new
            {
                usersCount = users.Count(),
                users = users,
            };

            string json = JsonConvert.SerializeObject(resObj, Formatting.Indented);

            return json;
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(config =>
            {
                config.AddProfile<ProductShopProfile>();
            }));
        }
    }
}