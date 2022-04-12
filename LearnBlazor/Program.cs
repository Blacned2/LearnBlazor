using LearnBlazor.Context;
using LearnBlazor.Data; 
using Microsoft.EntityFrameworkCore;
using Auth0.AspNetCore.Authentication;
using Radzen;
using LearnBlazor.AppService.Interface;
using LearnBlazor.AppService.Services;
using AutoMapper;
using LearnBlazor.AutoMapper.Profiles;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new CategoryProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
//builder.Services
//    .AddAuth0WebAppAuthentication(options => {
//        options.Domain = builder.Configuration["Auth0:Domain"];
//        options.ClientId = builder.Configuration["Auth0:ClientId"];
//    });
builder.Services.AddScoped<NotificationService>();  
builder.Services.AddScoped<TooltipService>();
builder.Services.AddDbContext<BlazorDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlazorConnString"));

}); 



var app = builder.Build();

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
//app.UseAuthentication(); 
//app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
