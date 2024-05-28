using ManagerLibrary;
using DBLibrary;
using IRepositories;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register repository interfaces and their implementations
builder.Services.AddScoped<IEmployeeRepo, EmployeeDBManager>();
builder.Services.AddScoped<ICustomerRepo, CustomerDBManager>();
builder.Services.AddScoped<IExerciseRepo, ExerciseDBManager>();
builder.Services.AddScoped<IWorkoutRepo, WorkoutDBManager>();

// Register manager services
builder.Services.AddScoped<EmployeeManager>();
builder.Services.AddScoped<CustomerManager>();
builder.Services.AddScoped<ExerciseManager>();
builder.Services.AddScoped<WorkoutManager>();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Login");
        options.AccessDeniedPath = new PathString("/Error");
        options.ExpireTimeSpan = TimeSpan.FromSeconds(30);
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

app.UseAuthentication(); // Ensure authentication is used
app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();
