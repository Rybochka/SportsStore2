using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Мяч волейбольный",
                        Description = "Любительский волейбольный мяч Demix.",
                        Category = "Волейбол",
                        Price = 699M
                    },
                    new Product
                    {
                        Name = "Наколенник Demix",
                        Description = "Эластичный неопреновый наколенник с воздухопроницаемой вставкой - важный элемент защитной экипировки! ",
                        Category = "Волейбол",
                        Price = 699M
                    },
                    new Product
                    {
                        Name = "Велосипед горный",
                        Description = "Усовершенствованный горный велосипед Stern Energy 29 — отличный выбор для активного отдыха.",
                        Category = "Велоспорт",
                        Price = 26999M
                    },
                    new Product
                    {
                        Name = "Велосипед для мальчиков",
                        Description = "Горный велосипед Stern Action 24 с алюминиевой рамой и дисковыми тормозами разработан специально для мальчиков 8–12 лет.",
                        Category = "Велоспорт",
                        Price = 21599M
                    },
                    new Product
                    {
                        Name = "Ракетка для большого тенниса Torneo 27\"",
                        Description = "Любительская ракетка для большого тенниса от Torneo подойдет начинающим игрокам.",
                        Category = "Теннис",
                        Price = 1599M
                    },
                    new Product
                    {
                        Name = "Мяч для большого тенниса Torneo",
                        Description = "Универсальный мяч для большого тенниса.",
                        Category = "Теннис",
                        Price = 149M
                    },
                    new Product
                    {
                        Name = "Набор теннисных мячей",
                        Description = "Набор универсальных мячей для большого тенниса Wilson Triniti Pro.",
                        Category = "Теннис",
                        Price = 1279M
                    },
                    new Product
                    {
                        Name = "Струна для большого тенниса",
                        Description = "Струна Wilson Champion's Choice Duo — модель, которую по достоинству оценили многие теннисисты.",
                        Category = "Теннис",
                        Price = 4199M
                    },
                    new Product
                    {
                        Name = "Намотка верхняя",
                        Description = "Тонкая намотка Head Supercomp идеально подойдет для продвинутых любителей.",
                        Category = "Теннис",
                        Price = 599M
                    });
            }
            context.SaveChanges();
        }
    }
}
