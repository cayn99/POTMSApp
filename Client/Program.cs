using BaseLibrary.Entities;
using Blazored.LocalStorage;
using Client;
using Client.ApplicationStates;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using ClientLibrary.Services.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<CustomHttpHandler>();
builder.Services.AddHttpClient("SystemApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7230/");
}).AddHttpMessageHandler<CustomHttpHandler>();
// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7230/") });
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

builder.Services.AddScoped<IGenericServiceInterface<PurchaseRequest>, GenericServiceImplementation<PurchaseRequest>>();
builder.Services.AddScoped<IGenericServiceInterface<OrderDelivery>, GenericServiceImplementation<OrderDelivery>>();
builder.Services.AddScoped<IGenericServiceInterface<PurchaseOrder>, GenericServiceImplementation<PurchaseOrder>>();
builder.Services.AddScoped<IGenericServiceInterface<AccountingApproval>, 
    GenericServiceImplementation<AccountingApproval>>();
builder.Services.AddScoped<IGenericServiceInterface<AccountingComplete>, 
    GenericServiceImplementation<AccountingComplete>>();
builder.Services.AddScoped<IGenericServiceInterface<Coa>, GenericServiceImplementation<Coa>>();
builder.Services.AddScoped<IGenericServiceInterface<Inspection>, GenericServiceImplementation<Inspection>>();
builder.Services.AddScoped<IGenericServiceInterface<OrderReceived>, GenericServiceImplementation<OrderReceived>>();

builder.Services.AddScoped<AllState>();

builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<SfDialogService>();

 //Register Syncfusion license 
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense
    ("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWH5edXRXQmBcUEF0V0Y=");

await builder.Build().RunAsync();
