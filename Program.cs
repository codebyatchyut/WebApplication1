var builder = WebApplication.CreateBuilder(args); //prepares the hosting infrastructure, including configuration for the web server

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();


// You enter the website URL in your browser.
// The request reaches the Windows Server over the network.
// A web server such as IIS may receive the request first.
// The frontend files (HTML, CSS, JavaScript) are returned to the browser.
// When Angular calls your backend API, that request reaches your .NET application, often through IIS to Kestrel.
// Your controller executes the code, retrieves data if needed, and returns a response, often JSON.
// The browser receives the response and displays the result.