using Cardbooth.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IAvailabilityService, FakeAvailabilityService>();

await builder.Build().RunAsync();