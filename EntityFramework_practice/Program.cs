using EntityFramework_practice.Extension;
using EntityFramework_practice.Extension.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.CustomSchemaIds(x => x.FullName);
});
builder.Services.AddDataContexts(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("/DataAnnotation").DataAnnotationEndpoints().WithTags("DataAnnotationEndpoints");
app.MapGroup("/PropertyClass").PropertyClassEndpoints().WithTags("PropertyClassEndpoints");
app.MapGroup("/FluentApi").FluentApiEndpoints().WithTags("FluentApiEndpoints");
app.Run();