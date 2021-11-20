using Cakes.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//builder.Services.AddElmahSetup(builder.Configuration);
builder.Services.AddSwaggerSetup();
builder.Services.AddServicesSetup(builder.Configuration);
builder.Services.AddJwtSetup(builder.Configuration);

//builder.Services.AddResponseCompression();

var app = builder.Build();

//app.UseResponseCompression();
//app.UseStaticFiles();

app.UseSwaggerDocumentation(app.Environment);

app.UseHttpsRedirection();


//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

//app.UseElmahSetup();

app.Run();
