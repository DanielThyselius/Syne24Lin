
# Steps
1. Identify problems
   - All code in main
   - Database and EmailSender dependencies
   - DateTime.Now
   - User and Invoice classes without behavior
   
2. Extract code to SendInvoiceReminder method

3. Solve Database and EmailSender dependencies
   - Add IUserRepository and IInvoiceRepository interfaces
   - Add IEmailSender interface
   - Add mocks for these interfaces
   
4. Solve DateTime.Now
   - Add IDateTimeProvider interface
   - Create a mock for this interface
   
5. Refactor User and Invoice classes
   - Add behavior to calculate days to due date in Invoice class
   - Add behavior to generate reminder message in User class
   
6. Use dependency injection to provide dependencies
   - Add constructor injection for IUserRepository, IInvoiceRepository, IEmailSender, and IDateTimeProvider
    - Use the injected dependencies in the SendInvoiceReminder method
