using Autofac.Extensions.DependencyInjection;
using Autofac;
using GraphQL;
using GraphQL.WebApi.Data.Context;
using GraphQL.WebApi.Data.Repositories;
using GraphQL.WebApi.GraphQL;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
           .ConfigureContainer<ContainerBuilder>(containerBuilder =>
           {
               containerBuilder.RegisterType<MovieRepository>().As<IMovieRepository>().InstancePerLifetimeScope();
               containerBuilder.RegisterType<QueryObject>().AsSelf().SingleInstance().UsingConstructor(typeof(IMovieRepository));
               containerBuilder.RegisterType<MutationObject>().AsSelf().SingleInstance().UsingConstructor(typeof(IMovieRepository));
           });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
       .AddEntityFrameworkInMemoryDatabase()
       .AddDbContext<MovieContext>(context => { context.UseInMemoryDatabase("MovieDb"); });

builder.Services.AddScoped<IMovieRepository, MovieRepository>()
    .AddGraphQL(options =>
    {
        options.AddErrorInfoProvider(o => o.ExposeExceptionDetails = builder.Environment.IsDevelopment());
        options.AddSchema<MovieReviewSchema>();
        options.AddGraphTypes(Assembly.GetExecutingAssembly());
        options.AddDataLoader();
        options.AddSystemTextJson();
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseGraphQL();
app.UseGraphQLAltair();

app.UseAuthorization();

app.MapControllers();

app.Run();
