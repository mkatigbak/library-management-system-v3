var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

/*
// Login and Registration
app.MapPost("/auth/login", () => Results.Ok(new { token = "fake-jwt-token" }));
app.MapPost("/auth/register", () => "Staff registered");

// Dashboard
app.MapGet("/dashboard", (int totalBooks, int totalBorrowings, int totalReaders) => $"Dashboard: {totalBooks} books, {totalBorrowings} active borrowings, {totalReaders} readers");

// Manage Books
app.MapGet("/books", () => "Here are all books");
app.MapPost("/books", () => Results.Created("/books/1", "Book added"));
app.MapPut("/books/{id}", (int id) => $"Book {id} updated");
app.MapDelete("/books/{id}", (int id) => $"Book {id} deleted");
app.MapGet("/books/{id}", (int id, bool availability) => $"Book with ID {id} | Available: {availability}");

// Manage Borrowings
app.MapGet("/borrowings", () => "Here are all borrowings");
app.MapPost("/borrowings", () => "Borrowing created");
app.MapPut("/borrowings/{id}", (int id) => $"Borrowing {id} updated");
app.MapDelete("/borrowings/{id}", (int id) => $"Borrowing {id} canceled");
app.MapGet("/borrowings/{id}", (int id, DateTime borrowDate, string readerInformation) => $"Borrowing {id} | Borrow date: {borrowDate.ToShortDateString()} | Book Details: Details | Reader: {readerInformation}");

// Reader Management
app.MapGet("/readers", () => "Here are all readers");
app.MapPost("/readers", () => "Reader added");
app.MapPut("/readers/{id}", (int id) => $"Reader {id} updated");
app.MapDelete("/readers/{id}", (int id) => $"Reader {id} deleted");
app.MapGet("/readers/{id}", (int id) => $"Reader {id}'s information");

// Reports
app.MapGet("/reports/borrowings", (DateTime startDate, DateTime endDate) =>
    $"Report from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}");

// Overdue
app.MapGet("/borrowings/{id}/overdue", (int id) => $"Overdue charge for borrowing {id}: $5.00");
*/
app.UseRouting();
app.MapControllers();

app.Run();