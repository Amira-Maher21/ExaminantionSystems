
using AutoMapper;
using ExaminantionSystem.Data;
using Microsoft.EntityFrameworkCore;
 using ExaminantionSystem.Profiles;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using ExaminantionSystem.Helpers;
namespace ExaminantionSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Context>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
                builder.RegisterModule(new AutoFacModule()));

            builder.Services.AddAutoMapper(typeof(MappingProfile));



 


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            MapperHelper.Mapper = app.Services.GetService<IMapper>();

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
