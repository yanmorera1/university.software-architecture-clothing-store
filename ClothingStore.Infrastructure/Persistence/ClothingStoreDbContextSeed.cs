using ClothingStore.Domain;
using ClothingStore.Domain.Common;
using Microsoft.Extensions.Logging;

namespace ClothingStore.Infrastructure.Persistence
{
    public static class ClothingStoreDbContextSeed
    {
        public static async Task SeedAsync(ClothingStoreDbContext context, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger<ClothingStoreDbContext>();

            if (!context.Sizes!.Any())
            {
                context.Sizes!.AddRange(GetDefaultSizes());
                await context.SaveChangesAsync();
            }
            if (!context.Types!.Any())
            {
                context.Types!.AddRange(GetDefaultTypes());
                await context.SaveChangesAsync();
            }
            if (!context.Products!.Any())
            {
                context.Products!.AddRange(GetDefaultProducts(context.Sizes.ToList(), context.Types.ToList()));
                await context.SaveChangesAsync();
            }

            await context.SaveChangesAsync();
            logger.LogInformation("Inserting data in context: {context}", typeof(ClothingStoreDbContext).Name);
        }

        private static int GenerateRandomIndex<T>(int minValue, int maxValue, List<T> list) where T : Entity
        {
            Random random = new Random();
            var val = 0;
            while (val == 0)
            {
                val = list.Where(s => s.Id == random.Next(minValue, maxValue)).Select(s => s.Id).FirstOrDefault();
            }
            return val;
        }


        private static IEnumerable<Product> GetDefaultProducts(List<Size> sizes, List<Domain.Type> types)
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Nike Sports",
                    SizeId = GenerateRandomIndex(1, 5, sizes),
                    TypeId = GenerateRandomIndex(1, 6, types),
                    Color = "Negro",
                    Available = true,
                    Price = 150000,
                },
                new Product
                {
                    Name = "Adidas Sports",
                    SizeId = GenerateRandomIndex(1, 5, sizes),
                    TypeId = GenerateRandomIndex(1, 6, types),
                    Color = "Blanco",
                    Available = true,
                    Price = 200000,
                },
                new Product
                {
                    Name = "Adidas Classics",
                    SizeId = GenerateRandomIndex(1, 5, sizes),
                    TypeId = GenerateRandomIndex(1, 6, types),
                    Color = "Beige",
                    Available = true,
                    Price = 250000,
                }
            };
        }

        private static IEnumerable<Domain.Type> GetDefaultTypes()
        {
            return new List<Domain.Type>
            {
                new Domain.Type
                {
                    Name = "Tenis"
                },
                new Domain.Type
                {
                    Name = "Camisa"
                },
                new Domain.Type
                {
                    Name = "Zapato"
                },
                new Domain.Type
                {
                    Name = "Pantaloneta"
                },
                new Domain.Type
                {
                    Name = "Sudaderas"
                }
            };
        }

        private static IEnumerable<Size> GetDefaultSizes()
        {
            return new List<Size>
            {
                new Size
                {
                    Name = "S"
                },
                new Size
                {
                    Name = "M"
                },
                new Size
                {
                    Name = "L"
                },
                new Size
                {
                    Name = "XL"
                },
            };
        }
    }
}
