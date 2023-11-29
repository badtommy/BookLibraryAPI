using BookLibraryAPI.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibraryAPI.Tests
{
    public class TestWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram>
        where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<EFContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<EFContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });


                var sp = services.BuildServiceProvider();


                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<EFContext>();
                    db.Database.EnsureCreated();

                    // Seedování databáze
                    SeedDatabase(db);
                }
            });
        }

        private void SeedDatabase(EFContext dbContext)
        {
            dbContext.Books.Add(new BookLibraryAPI.Domain.Models.Book
            {
                Id = new System.Guid("7cf6b5f9-5867-430b-ba0e-ba17a115e302"),
                Title = "Kniha 1",
                Author = "Author 1",
                ISBN = "123456789",
                State = BookLibraryAPI.Domain.Enums.BookStateEnum.AVAILABLE

            });

            dbContext.Books.Add(dbContext.Books.Add(new BookLibraryAPI.Domain.Models.Book
            {
                Id = new System.Guid("7cf6b5f9-5867-430b-ba0e-ba17a115e303"),
                Title = "Kniha 2",
                Author = "Author 2",
                ISBN = "123456789",
                State = BookLibraryAPI.Domain.Enums.BookStateEnum.AVAILABLE

            }).Entity);

            dbContext.Books.Add(dbContext.Books.Add(new BookLibraryAPI.Domain.Models.Book
            {
                Id = new System.Guid("7cf6b5f9-5867-430b-ba0e-ba17a115e304"),
                Title = "Kniha 3",
                Author = "Author 3",
                ISBN = "123456789",
                State = BookLibraryAPI.Domain.Enums.BookStateEnum.AVAILABLE

            }).Entity);

            dbContext.SaveChanges();
            // Sem přidáte logiku pro naplnění databáze
        }
    }
}
