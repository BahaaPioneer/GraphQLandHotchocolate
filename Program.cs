using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr")));

builder.Services.AddGraphQLServer()
                //.RegisterDbContext<AppDbContext>(DbContextKind.Pooled)
                .AddQueryType<Query>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();
