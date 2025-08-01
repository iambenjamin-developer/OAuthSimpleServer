using Duende.IdentityServer.Models;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Add IdentityServer
            builder.Services.AddIdentityServer()
                    .AddInMemoryApiScopes(new[]
                    {
                        new ApiScope("api1", "My API")
                    })
                    .AddInMemoryClients(new[]
                    {
                        new Client
                        {
                            ClientId = "client",
                            AllowedGrantTypes = GrantTypes.ClientCredentials,
                            ClientSecrets = { new Secret("secret".Sha256()) },
                            AllowedScopes = { "api1" }
                        }
                    });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
