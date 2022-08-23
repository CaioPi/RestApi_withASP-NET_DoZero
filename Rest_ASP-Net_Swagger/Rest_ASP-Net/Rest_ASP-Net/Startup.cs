using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rest_ASP_Net.Model.Context;
using Rest_ASP_Net.Business;
using Rest_ASP_Net.Business.Implementations;
using System;
using System.Collections.Generic;
using Rest_ASP_Net.Repository;
using Serilog;
using Rest_ASP_Net.Repository.Generic;
using System.Net.Http.Headers;
using Rest_ASP_Net.Hypermedia.Filters;
using Rest_ASP_Net.Hypermedia.Enricher;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

namespace Rest_ASP_Net
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Habilitando serviço CORS
            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddControllers();

            var connection = Configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MysqlContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

            if (Environment.IsDevelopment())
            {
                MigrateDatabase(connection);

            }

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml").ToString());

                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json").ToString());

            })
            .AddXmlSerializerFormatters();

            var filterOptions = new HypermediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());

            services.AddSingleton(filterOptions);


            //versioning api
            services.AddApiVersioning();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "REST API's From 0 to Azure with ASP.NET Core 5 and Docker",
                    Version = "v1",
                    Description = "API RESTful developed in course 'REST API's From 0 to Azure with ASP.NET Core 5 and Docker'",
                    Contact = new OpenApiContact
                    {
                        Name = "Caio Pinelli",
                        Url = new Uri("https://github.com/caiopi")
                    }
                });
            });

                //injeção de dependencia
                services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
                //services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

                services.AddScoped<IBookBusiness, BookBusinessImplementation>();
                //services.AddScoped<IBookRepository, BookRepositoryImplementation>();

                services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            }

        private static void MigrateDatabase(string connection)
            {
                try
                {
                    var evolveConnection = new MySqlConnector.MySqlConnection(connection);
                    var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                    {
                        Locations = new List<string> { "db/migrations", "db/dataset" },
                        IsEraseDisabled = true,
                    };
                    evolve.Migrate();
                }
                catch (Exception ex)
                {

                    Log.Error("Database migration failed", ex);
                    throw;

                }
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseHttpsRedirection();

                app.UseRouting();

            //Habilitando CORS, SEMPRE deve ficar depois de
            //"app.UseHttpsRedirection();" e "app.UseRouting();", e também antes de app.UseEndpoints
            app.UseCors();    

                app.UseSwagger();

                
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json",
                        "REST API's From 0 to Azure with ASP.NET Core 5 and Docker - v1");
                });

                var option = new RewriteOptions();

                option.AddRedirect("^$", "swagger");
                app.UseRewriter(option);


                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();

                    endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
                });
            }
        }
    }
