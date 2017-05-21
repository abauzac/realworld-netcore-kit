using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using MongoDB.Bson.Serialization.Conventions;
using Newtonsoft.Json.Serialization;
using Sandbox.Server.BusinessLogic.Handlers;
using Sandbox.Server.DataAccess.Repositories;
using Sandbox.Server.DomainObjects.Interfaces.Handlers;
using Sandbox.Server.DomainObjects.Interfaces.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Sandbox.Server.Http
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            /* DEPENDENCY INJECTIONS */

            // Data access dependency injection
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IArticleRepository, ArticleRepository>();
            services.AddSingleton<ICommentRepository, CommentRepository>();

            // Business logic dependency injection
            services.AddSingleton<IPersonHandler, PersonHandler>();
            services.AddSingleton<IArticleHandler, ArticleHandler>();
            services.AddSingleton<ICommentHandler, CommentHandler>();

            /* SWAGGER */

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API v1", Version = "API v1" });
                // Add new API version below
                //c.SwaggerDoc("v2", new Info { Title = "My API v2", Version = "API v2" });

                // Uncomment in case you want Swagger API versioning
                // In this case, all your routes have to be something like /api/v1/user
                // c.DocInclusionPredicate((docName, api) => {
                //     return api.RelativePath.Contains(docName);
                // });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Open database connections
            DataAccess.Repositories.Abstract.MongoCollectionHandler
                .OpenConnections(
                    Configuration.GetConnectionString("readOnlyAccess"),
                    Configuration.GetConnectionString("writeAccess"));

            // when de/serializing an object, we want to ignore null values when calling ToBsonDocument()
            // ConventionRegistry.Register("IgnoreIfNull",
            //                             new ConventionPack { new IgnoreIfNullConvention(true) },
            //                             t => true);
            ConventionRegistry.Register("IgnoreIfDefault",
                            new ConventionPack { new IgnoreIfDefaultConvention(true) },
                            t => true);


            app.UseMvc();

            if(env.IsDevelopment()){
                app.UseSwagger();

                app.UseSwaggerUi(c => {
                    //c.SwaggerEndpoint("/swagger/v2/swagger.json", "V2 Docs");
                    // Add new Api version above
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Docs");
                });
            }
        }
    }
}
