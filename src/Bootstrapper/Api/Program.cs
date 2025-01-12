// Initialize the web application builder

var builder = WebApplication.CreateBuilder(args);

//Add Services into the DI Container
///Register the servics which our app will use
///(custom sercies , DB Context, Identity services, and any other dependencies)
///

builder.Services.AddControllers();
//Register Custm services

//builder.Services.AddTransient<IMyService,MyService>(); //create new instance of the service each time it is requested
builder.Services.AddScoped<ILogger, ILogger>(); //Create new instance of the service per request(Most used)
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);//create single instancce from the service  for the life time of the application

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//Configure the http request pipeline and build the web app

//run the web app
app.Run();


//Accumulating the dependencies from diff modules DI

//Each module has DI Class To register its own services
//Create extension method for each module to encapsulate the registeration logic