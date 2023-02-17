var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();//Middleware
    //app.UseSwaggerUI();//Middleware
}

app.UseHttpsRedirection();//Middleware

app.UseCors();


app.UseAuthorization();//Middleware
//Acá inician los custom middlewares

//app.UseTimeMiddleware();
//app.UseWelcomePage();//Middleware para mostrar una página de bienvenida personalizada

//Acá terminan los custom middlewares
app.MapControllers();

app.Run();
