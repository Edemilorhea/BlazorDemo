global using BlazorDemo.Shared.Model;
global using BlazorDemo.Shared.Services;
global using BlazorDemo.Client.Pages;
using BlazorDemo.Shared.DBData;
using System.Reflection.Metadata;
using BlazorDemo.Components;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using NSwag;
using Microsoft.AspNetCore.Http.Features;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument( options => {
    options.PostProcess = document =>
    {
        document.Info =  new OpenApiInfo{
            Title = "BlazorDemo",
            Version = "1.0.0",
            Description = "BlazorDemo",
            TermsOfService = "https://example.com/terms",
            Contact = new OpenApiContact
            {
                Name = "Example Contact",
                Url = "https://example.com/contact"
            },
            License = new OpenApiLicense
            {
                Name = "Example License",
                Url = "https://example.com/license"
            }
        };
    };
});

builder.Services.AddControllers();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value!),
});

builder.Services.AddMongoDB<DataContext>("mongodb://localhost:27017", "Blazor");
builder.Services.AddScoped<IBookServices, BookServices>();


builder.Services
    .AddBlazorise( options =>
    {
        options.Immediate = true;
    } )
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3(c => 
        {
            c.DocumentPath = "/swagger/v1/swagger.json";
            c.DocExpansion = "list";
        });
    app.UseReDoc();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

// app.MapPost("api/[controller]/[action]", async context =>{
//     context.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = 100*1024*1024;
// });

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();
