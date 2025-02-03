
# Steps

1. Identify problems
   - All code in main
   - Database and FileWriter dependencies
   - Product and Category classes without behavior

2. Extract code to GenerateCategoryReports method

3. Solve Database and FileWriter dependencies
   - Add IProductRepository and ICategoryRepository interfaces
   - Add IFileWriter interface
   - Add mocks for these interfaces

4. Refactor Product and Category classes
   - Add behavior to calculate revenue in Product class
   - Add behavior to generate report content in Category class

5. Use dependency injection to provide dependencies
   - Add constructor injection for IProductRepository, ICategoryRepository, and IFileWriter
   - Use the injected dependencies in the GenerateCategoryReports method
   - 