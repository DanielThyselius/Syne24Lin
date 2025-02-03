// This is NOT how you should be coding!

var db = new Database();
var emailSender = new EmailSender();
var user = db.GetUser("john@example.com");
var invoice = db.GetInvoice(user.Id);
var dueDate = invoice.DueDate;
var daysToDueDate = (dueDate - DateTime.Now).Days;
var message = $"Dear {user.Name},\n\nYour invoice of {invoice.Amount} is due in {daysToDueDate} days.\n\nBest regards,\nThe Invoice Team";
emailSender.SendEmail(user.Email, "Invoice Reminder", message);

public class Database
{
    // Let's pretend this actually connects to a database
    public User GetUser(string email) => new User { Id = 1, Name = "John Doe", Email = email };
    public Invoice GetInvoice(int userId) => new Invoice { UserId = userId, Amount = 100, DueDate = DateTime.Now.AddDays(7) };
}

public class EmailSender
{
    public void SendEmail(string to, string subject, string body)
    {
        // Let's pretend this actually sends an email
        Console.WriteLine($"Sending email to {to} with subject '{subject}' and body:\n{body}");
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Invoice
{
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
}
