var builder = WebApplication.CreateBuilder(args);
var sessionCookieName = "UserSession";

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache(); // Use distributed memory cache for session storage
builder.Services.AddSession(options =>
{
    options.Cookie.Name = sessionCookieName;
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});


var app = builder.Build();

app.UseSession();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
