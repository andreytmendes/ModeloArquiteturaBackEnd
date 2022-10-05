using System;
using System.Globalization;
using System.Text.Json.Serialization;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Lideranca.Data.Data.Context;
using Lideranca.Data.Data.Repositories;
using Lideranca.Data.Domain.DTOs;
using Lideranca.Data.Domain.Entities;
using Lideranca.Data.Domain.Interfaces;
using Lideranca.Data.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

namespace Lideranca.Data.Api
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IConfiguration>(_configuration);
            services.AddDbContext<AutenticationContext>(options => options.UseSqlServer(_configuration.GetSection("ConnectionString").Value));

            #region Repositorys
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<IBaseRepository<TestEntity>, BaseRepository<TestEntity>>();
            #endregion Repository

            #region Services
            services.AddScoped<IBaseService<TestEntity>, BaseService<TestEntity>>();
            services.AddScoped<ITestService, TestService>();
            #endregion Services

            #region AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                //Get all profiles
                mc.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            });

            services.AddSingleton(mappingConfig.CreateMapper());
            #endregion AutoMapper

            #region Fluent Validation DTO's
            services.AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters()
                    //.AddFluentValidation(config =>
                    //{
                    //    config.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-br");
                    //})
                    .AddMvc()
                    .AddNewtonsoftJson(option =>
                    {
                        option.SerializerSettings.Converters.Add(new IsoDateTimeConverter
                        {
                            DateTimeStyles = DateTimeStyles.AdjustToUniversal,
                            DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ"
                        }); ;
                    });

            services.AddTransient<IValidator<TestDTO>, TestDTOValidator>();
            services.AddTransient<IValidator<TestUpdateDTO>, TestUpdateDTOValidator>();
            #endregion

            services.AddControllers()
                    .AddJsonOptions(x => x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddSwaggerGen(x =>
            {
                x.EnableAnnotations();
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Lideranca.Data.Api - Dados",
                    Description = "API para Retorno dos dados da Aplicação",
                    Contact = new OpenApiContact
                    {
                        Name = "Teste",
                        Email = "admin@teste.com.br",
                        Url = new Uri("http://www.teste.com.br/"),
                    }

                });
            });

            ConfigureCors(services);

        }

        private static void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins(new string[] { "*.heroku.com.br" })
                           .AllowAnyMethod()
                           .AllowCredentials()
                           .AllowAnyHeader();
                });

                option.AddPolicy("LocalCorsPolicy", builder =>
                {
                    builder.SetIsOriginAllowed((host) => true)
                           .AllowAnyMethod()
                           .AllowCredentials()
                           .AllowAnyHeader();
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {

            app.UseCors("LocalCorsPolicy");

            //app.UseAzureAdAuthConfiguration();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Lideranca.Data.Api");
                options.RoutePrefix = "swagger";
            });

            app.UseSwaggerUI();

            //app.UseHttpsRedirection();

            //app.UseAuthorization();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

        }
    }
}
