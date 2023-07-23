using Web.Bussiness.IRepository;
using Web.Bussiness.Mapper;
using Web.Bussiness.Repository;
using Web.DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
});
builder.Services.AddDbContext<PRN211_FinalProjectContext>(opt => builder.Configuration.GetConnectionString("Northwind"));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IScheduleRepository, ScheduleRepository>();
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
app.UseSession();

app.UseAuthorization();
app.UseAuthentication();
app.MapRazorPages();

app.Run();
