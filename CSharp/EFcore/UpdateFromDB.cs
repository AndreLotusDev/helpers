using Microsoft.EntityFrameworkCore;

var dbContext = new YourDbContext();

var rowsAffected = await dbContext.Products
    .Where(p => p.CategoryId == 2)
    .ExecuteUpdateAsync(p => new Product {Price = p.Price * 1.1});

Console.WriteLine($"{rowsAffected} rows were updated.");
