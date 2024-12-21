using AutomationListLibrary.DataAccess;
using AutomationListLibrary.DataManager;
using AutomationListLibrary.FileAcces;
using AutomationListLibrary.MetaData;
using AutomationListUI.Services;
using Microsoft.Data.SqlClient;
using MudBlazor.Services;
using Syncfusion.Blazor;

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<ISqlConnector, SqlConnector>();
builder.Services.AddSingleton<IObjectDataManager, ObjectDataManager>();
builder.Services.AddSingleton<IObjectService, ObjectService>();
builder.Services.AddSingleton<ITagService, TagService>();
builder.Services.AddSingleton<CategoryDataManager>();
builder.Services.AddSingleton<SubCategoryDataManager>();
builder.Services.AddSingleton<TagDataManager>();
//builder.Services.AddSingleton<CustomerObjects.CustomAdaptor>();
builder.Services.AddSingleton<ExcelConnector>();
builder.Services.AddSingleton<SqlConnectionStringBuilder>();
builder.Services.AddTransient<DatabaseManager>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddMudServices();

var app = builder.Build();

//Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXheeHRTRWdfWEV0V0Q=");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
