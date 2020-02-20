using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopSchema;

namespace GraphQLIn.Net
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddGraphQL(options =>
             {
                 options.EnableMetrics = true;
                 options.ExposeExceptions = _environment.IsDevelopment();
             })
             .AddDataLoader();             

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            })
            .Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            })

            .AddSingleton<IProduct, ProductRepository>()
            .AddSingleton<IBasket, BasketRepository>()
            .AddSingleton<SchemaShop>();
        }
       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            

            app.UseHttpsRedirection();            

            app.UseGraphQL<SchemaShop>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground",
                GraphQLEndPoint = "/graphql",
            });

            app.UseRouting();           
        }
    }
}
