using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("ProductsDb"));

builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Middleware
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Products.AddRange(
        new Product { Name = "Laptop", Price = 80000 },
        new Product { Name = "Phone", Price = 30000 },
        new Product { Name = "Headphones", Price = 2000 }
    );

    db.SaveChanges();
}

app.Run();