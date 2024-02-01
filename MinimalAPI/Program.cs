using MinimalAPI.MiddlewareExtensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var response = new List<string>();

app.UseHttpsRedirection();


//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Primeira passagem.\n");
//    await next();
//    await context.Response.WriteAsync("Segunda passagem (retorno)");
//});

/* Forma 1 */
//app.UseMiddleware<ExampleMiddleware>();

/*Forma 2 */
//app.UseExampleMiddleware();

app.UseChassiMiddleware(response);
app.UseMotorMiddleware(response);
app.UsePortasMiddleware(response);
app.UsePinturaMiddleware(response);
app.UseInternoMiddleware(response);


app.Run(async context =>
{
    response.Add("CARRO FINALIZADO");
    //await context.Response.WriteAsync(String.Join("\n", response));
});



app.Run();
