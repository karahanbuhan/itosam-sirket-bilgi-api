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

// TODO: Scrap from: https://www.borsaningundemi.com/piyasa-ekrani/hisse-detay/TUPRS
System.Xml.XmlDocument docXML = new System.Xml.XmlDocument();
docXML.Load("https://www.borsaningundemi.com/piyasa-ekrani/bist-hisseler");
string innerText = docXML.InnerText;

app.MapGet("/scrapper", () =>
{
    return innerText;
}).WithName("ScrapCompanies");

app.MapGet("/companies", () =>
{
    return companies;
})
.WithName("ListCompanies");

app.Run();

record Company(string CompanyName, DateOnly CreationDate, double BookValue, double MarketValue)
{

}
