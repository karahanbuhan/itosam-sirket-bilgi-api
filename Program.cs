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

var companies2026_06_30 = new Company[]
{
    new Company("A1CAP", 7337250000, 13.42),
    new Company("A1YEN", 1794000000, 5.63),
    new Company("AAGYO", 11223010000, 19.49),
    new Company("ACSEL", 1437779970, 59.56),
    new Company("ADEL", 8290012500, 5.00),
    new Company("ADESE", 4989600000, 2.76),
    new Company("ADGYO", 29448846768, 29.18),
    new Company("AEFES", 127539473650, 20.15),
    new Company("AFYON", 5324000000, 19.16),
    new Company("AGESA", 45405000000, 54.85),
    new Company("AGHOL", 82899149927, 51.93),
    new Company("AGROT", 6576000000, 3.31),
    new Company("AGYO", 2098819800, 23.80),
    new Company("AHGAZ", 98644000000, 21.04),
    new Company("AHSGY", 14271270000, 13.91),
    new Company("AKBNK", 404820000000, 58.19),
    new Company("AKCNS", 39629543076, 142.10),
    new Company("AKENR", 8626010120, 19.96),
    new Company("AKFGY", 10959000000, 9.12),
    new Company("AKFIS", 46120516451, 56.04),
    new Company("AKFYE", 28798916450, 52.06),
    new Company("AKGRT", 11509680000, 4.85),
    new Company("AKHAN", 9179093000, 19.02),
    new Company("AKMGY", 9271283200, 283.92),
    new Company("AKSA", 45843000000, 8.66),
    new Company("AKSEN", 102337925794, 52.30),
    new Company("AKSGY", 22918350000, 20.39),
    new Company("AKSUE", 2502720000, 15.00),
    new Company("AKYHO", 615511200, 2.66),
    new Company("ALARK", 44243700000, 197.40),
    new Company("ALBRK", 20300000000, 10.23),
    new Company("ALCAR", 8364600000, 188.26),
    new Company("ALCTL", 6656532784, 86.24),
    new Company("ALFAS", 17641920000, 15.96),
    new Company("ALGYO", 8236116000, 8.67),
    new Company("ALKA", 6923700000, 3.01),
    new Company("ALKIM", 5484000000, 14.94),
    new Company("ALKLC", 38668000000, 25.57),
    new Company("ALTNY", 16570000000, 5.03),
    new Company("ALVES", 4304000000, 1.88),
    new Company("ANELE", 29547500000, 8.59),
    new Company("ANGEN", 2321000000, 7.95),
    new Company("ANHYT", 44161000000, 24.65),
    new Company("ANSGR", 55160000000, 21.17),
};

app.MapGet("/companies2026-06-30", () =>
{
    return companies2026_06_30;
})
.WithName("ListCompanies");

app.Run();

record Company(string CompanyName, double BookValue, double MarketValue)
{

}
