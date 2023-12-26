using EntityFramework_practice.Extension;
using EntityFramework_practice.Extension.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataContexts(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("/DataAnnotation").DataAnnotationEndpoints().WithTags("DataAnnotationEndpoints");
app.Run();