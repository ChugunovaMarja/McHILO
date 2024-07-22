using McHILO.Configuration;
using McHILO.Controller;
using McHILO.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var serviceCollection = new ServiceCollection();

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
serviceCollection.Configure<ValidationConfiguration>(configuration.GetSection("ValidationConfiguration"));
serviceCollection.Configure<GameConfiguration>(configuration.GetSection("GameConfiguration"));

serviceCollection.AddTransient<IInputReaderService, InputReaderService>();
serviceCollection.AddTransient<IRangeReaderService, RangeReaderService>();
serviceCollection.AddTransient<IUserGuessReaderService, UserGuessReaderService>();
serviceCollection.AddTransient<IUserReaderService, UserReaderService>();
serviceCollection.AddTransient<IUserRegistrationService, UserRegistrationService>();
serviceCollection.AddTransient<IRoundService, RoundService>();
serviceCollection.AddTransient<IIterationService, IterationService>();
serviceCollection.AddTransient<IRoundController, RoundController>();
serviceCollection.AddTransient<IGameController, GameController>();
serviceCollection.AddTransient<IRangeRegistrationService, RangeRegistrationService>();
serviceCollection.AddTransient<MainController>();

var serviceProvider = serviceCollection.BuildServiceProvider();


serviceProvider.GetService<MainController>().Start();