using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjectionSwagger
    {
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1", 
                    new OpenApiInfo 
                    { 
                        Title = "FandomStarWars.API", 
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Isaque Diniz da Silva",
                            Email = "isaquediniz14@gmail.com",
                            Url = new Uri("https://www.linkedin.com/in/isaque-diniz-da-silva-a0773459/")
                        }
                    });

                var xmlFile = "FandomStarWars.API.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    //definir configuracoes
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] " +
                    "and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                      {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });

                // Reduz o número de arquivos temporários gerados pelo Swagger
                c.UseOneOfForPolymorphism();
                c.UseAllOfForInheritance();
                c.UseInlineDefinitionsForEnums();
                c.IgnoreObsoleteProperties();
                c.GeneratePolymorphicSchemas();

            });
            return services;
        }
    }
}

