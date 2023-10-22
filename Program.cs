using FluentValidation;
using Microsoft.OpenApi.Models;
using VATCalculatorAPI.Models;
using VATCalculatorAPI.Services;
using VATCalculatorAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 443;
});

builder.Services.AddCors(options => {
    options.AddPolicy("AllowOrigin", builder => {
        builder.WithOrigins("https://localhost:5178")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddScoped<IVATCalculatorService, VATCalculatorService>();
builder.Services.AddTransient<IValidator<PurchaseAmount>, PurchaseAmountValidator>(); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VAT Calculator API", Version = "v1" });
});

var app = builder.Build();

app.UseCors("AllowOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
