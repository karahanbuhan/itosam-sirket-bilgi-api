var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var companies = new Company[]
{
    new Company("TÜPRAŞ - Türkiye Petrol Rafinerileri A.Ş.", new DateOnly(2015, 3, 18), 422.35, 183.55),
};

// Add scrapper and get company information

app.MapGet("/companies", () =>
{
    return companies;
})
.WithName("ListCompanies");

app.Run();

record Company(string CompanyName, DateOnly CreationDate, double BookValue, double MarketValue)
{
    
}
