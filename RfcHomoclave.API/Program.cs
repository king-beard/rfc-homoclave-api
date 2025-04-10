using RfcHomoclave.API.Extensions;
using RfcHomoclave.API.Extensions.Swagger;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;

// Add services to the container.

services.AddDependencyInjection();
services.AddControllers(config => { config.Conventions.Add(new ControllerModelConvention()); });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
services.AddOpenApi();
services.AddServiceSwagger();

services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger(c => c.RouteTemplate = "/kb-rfc-service/swagger/v1/{documentName}/swagger.json");
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("rfc_homoclave/swagger.json", "RFC Homoclave Service");
    c.RoutePrefix = "kb-rfc-service/swagger/v1";
});

app.UseStaticFiles();

app.Run();
