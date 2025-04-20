using LibraryManagementSystem2.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSession();

builder.Services.AddSingleton<BookRepository>();
builder.Services.AddSingleton<ReaderRepository>();
builder.Services.AddSingleton<BorrowingRepository>();
builder.Services.AddSingleton<UserRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();