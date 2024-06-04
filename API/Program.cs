using API.Common.Specifications;
using API.Context;
using API.Entities.Specifications.Tasks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDbContext<ApplicationDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/find-done-by-title", async (string title) =>
    {
        // This is a simple example of how to use the Specification pattern
        var configuration = app.Services.GetRequiredService<IConfiguration>();

        // This is a simple example of how to use the Specification pattern
        var context = new ApplicationDbContext(configuration);

        // This is a simple example of how to use the Specification pattern
        var query = context.Tasks.AsQueryable();

        // This is a simple example of how to use the Specification pattern
        var specification =
            new TitleContainsSpecification(title)
            & new CompletedTaskSpecification();

        // Ex, query = query.Where(task => task.Title.Contains(title) && task.IsDone);
        query = query.Where(specification);

        // query = query.Where(new TitleContainsSpecification(title) & new CompletedTaskSpecification());
        var list = await query.ToListAsync();

        return list;
    })
    .WithName("find-done-by-title")
    .WithOpenApi();

app.MapGet("/find-not-completed", async (string title) =>
    {
        // This is a simple example of how to use the Specification pattern
        var configuration = app.Services.GetRequiredService<IConfiguration>();

        // This is a simple example of how to use the Specification pattern
        var context = new ApplicationDbContext(configuration);

        // This is a simple example of how to use the Specification pattern
        var query = context.Tasks.AsQueryable();

        // This is a simple example of how to use the Specification pattern
        var specification = !new CompletedTaskSpecification();

        // Ex, query = query.Where(task => !task.IsDone);
        query = query.Where(specification);

        // query = query.Where(! new CompletedTaskSpecification());
        var list = await query.ToListAsync();

        return list;
    })
    .WithName("find-not-completed")
    .WithOpenApi();

app.MapGet("/find-completed", async (string title) =>
    {
        // This is a simple example of how to use the Specification pattern
        var configuration = app.Services.GetRequiredService<IConfiguration>();

        // This is a simple example of how to use the Specification pattern
        var context = new ApplicationDbContext(configuration);

        // This is a simple example of how to use the Specification pattern
        var query = context.Tasks.AsQueryable();

        // This is a simple example of how to use the Specification pattern
        var specification = new CompletedTaskSpecification();

        // Ex, query = query.Where(task => task.IsDone);
        query = query.Where(specification);

        // query = query.Where(new CompletedTaskSpecification());
        var list = await query.ToListAsync();

        return list;
    })
    .WithName("find-completed")
    .WithOpenApi()
    ;

app.MapGet("/find-all", async () =>
    {
        // This is a simple example of how to use the Specification pattern
        var configuration = app.Services.GetRequiredService<IConfiguration>();

        // This is a simple example of how to use the Specification pattern
        var context = new ApplicationDbContext(configuration);

        // This is a simple example of how to use the Specification pattern
        var query = context.Tasks.AsQueryable();

        var list = await query.ToListAsync();

        return list;
    })
    .WithName("find-all")
    .WithOpenApi()
    ;


app.Run();