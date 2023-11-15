using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShopAPI2.Models.DataBaseModels;
using ShopAPI2.Models.Help;
using ShopAPI2.Models.DTO;
using ShopAPI2.Services.DTOServices.Help;
using ShopAPI2.Services.DTOServices;

namespace ShopAPI2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                var basePath = AppContext.BaseDirectory;

                var xmlPath = Path.Combine(basePath, "ShopAPI2.xml");
                options.IncludeXmlComments(xmlPath);
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ShopAPI",
                    Description = "������������ �� ������ � API",

                });
            });

            builder.Services.AddAuthorization();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = JwtTokenOptions.ISUURE,
                        ValidateAudience = true,
                        ValidAudience = JwtTokenOptions.AUDIENCE,
                        ValidateLifetime = true,
                        IssuerSigningKey = JwtTokenOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                    options.RequireHttpsMetadata = true;
                });

            builder.Services.AddDbContext<DataBaseWorker>(opt =>
                opt.UseNpgsql(builder.Configuration.GetConnectionString("DBContection")));

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<IDTOServices<UserDTO>, UserDTOService>();
            builder.Services.AddScoped<IDTOServices<RoleDTO>, RoleDTOService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}