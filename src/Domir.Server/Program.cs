using Domir.Server.UseCases.Login;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

// Add MagicOnion services to the container and enable JSON transcoding feature.
builder.Services.AddMagicOnion().AddJsonTranscoding();

// Add MagicOnion JSON transcoding Swagger support.
builder.Services.AddMagicOnionJsonTranscodingSwagger();

builder.Services.AddEndpointsApiExplorer();

// // JwtBearer authentication
// builder.Services.AddAuthentication().AddJwtBearer();
// builder.Services.AddAuthorization();

// Add Swagger generator services.
builder.Services.AddSwaggerGen(options =>
{
    // Reflect the XML documentation comments of the service definition in Swagger.
    // options.IncludeMagicOnionXmlComments(Path.Combine(AppContext.BaseDirectory, "AppNamePlaceholder.Shared.xml"));

    // // Add JWT security scheme to Swagger. 
    // options.AddJwtSecurityScheme();
});

builder.Services.AddSingleton<ILoginUseCase, LoginUseCase>();

var app = builder.Build();
app.UseSwagger();

if (app.Environment.IsDevelopment())
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

app.MapMagicOnionService();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();