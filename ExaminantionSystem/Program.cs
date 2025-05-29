using AutoMapper;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ExaminantionSystem.Data;
using ExaminantionSystem.Helpers;
using ExaminantionSystem.middleware;
using ExaminantionSystem.Profiles;
using ExaminantionSystem.Services.user;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using ExaminantionSystem.Models;
using System.Text.Json.Serialization;

namespace ExaminantionSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // إعداد قاعدة البيانات
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // استخدام Autofac كـ DI Container
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
                containerBuilder.RegisterModule(new AutoFacModule()));

            // تسجيل TokenGenerator في DI
            builder.Services.AddScoped<TokenGenerator>();

            // إضافة AutoMapper مع ملف MappingProfile
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // إعداد المصادقة باستخدام JWT Bearer
            builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWT"));
            var jwtSettingsSection = builder.Configuration.GetSection("JWT");

             builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettingsSection["Issuer"],
                    ValidAudience = jwtSettingsSection["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettingsSection["SecretKey"]))
                };
            });


    //        builder.Services.AddControllers()
    //.AddJsonOptions(opts =>
    //{
    //    opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    //});



            // إضافة خدمات التحكم بالـ API
            builder.Services.AddControllers();

            // إعداد Swagger / OpenAPI مع دعم التوثيق بـ JWT
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExaminantionSystem", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "أدخل التوكن هنا: Bearer {token}"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new string[] { }
                    }
                });
            });

            var app = builder.Build();

            // تعيين Mapper Helper
            MapperHelper.Mapper = app.Services.GetService<IMapper>();

            // تسجيل Middleware التعامل مع الأخطاء
            app.UseMiddleware<GlobalErrorHandling>();

            // تمكين المصادقة والتفويض
            app.UseAuthentication();
            app.UseAuthorization();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
