namespace SupressNulls
{
    using GraphQL.AspNet;
    using GraphQL.AspNet.Configuration;
    using GraphQL.AspNet.Interfaces.Engine;
    using GraphQL.AspNet.Schemas;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // register the custom response writer for the default schema
            // this will prevent the library from registering the default
            builder.Services.AddSingleton<IQueryResponseWriter<GraphSchema>, NullSupressingResponseWriter<GraphSchema>>();

            builder.Services.AddGraphQL();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseGraphQL();
            app.Run();
        }
    }
}