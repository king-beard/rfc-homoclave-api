using Microsoft.OpenApi.Models;
using RfcHomoclave.Middleware.Helpers.Constants;

namespace RfcHomoclave.API.Extensions.Swagger
{
    public static class ServiceSwagger
    {
        public static IServiceCollection AddServiceSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerConst.RfcHomoclaveName, new OpenApiInfo
                {
                    Version = SwaggerConst.ServiceVersion,
                    Title = SwaggerConst.RfcHomoclaveTitle
                });


                c.AddSecurityDefinition(SwaggerConst.Bearer, new OpenApiSecurityScheme
                {
                    Description = SwaggerConst.Description,
                    Name = SwaggerConst.DefinitionName,
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = SwaggerConst.Bearer
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                        new List<string>()
                    }
                });

                c.CustomSchemaIds(x => x.Name.Replace("Dto", string.Empty));
            });
            return services;
        }
    }
}
