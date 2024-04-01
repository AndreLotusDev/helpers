using Microsoft.EntityFrameworkCore;

var dbContext = new YourDbContext();

var rowsAffected = await dbContext.Products
    .Where(p => p.CategoryId == 2)
    .ExecuteUpdateAsync(p => new Product {Price = p.Price * 1.1});

Console.WriteLine($"{rowsAffected} rows were updated.");

//Do update using update API and property casting
context.Blogs
    .Where(b => b.Rating < 3)
    .ExecuteUpdate(setters => setters.SetProperty(b => b.IsVisible, false));

//More than one property
context.Blogs
    .Where(b => b.Rating < 3)
    .ExecuteUpdate(setters => setters
        .SetProperty(b => b.IsVisible, false)
        .SetProperty(b => b.Rating, 0));

//Update using the property value itself as reference
context.Blogs
    .Where(b => b.Rating < 3)
    .ExecuteUpdate(setters => setters.SetProperty(b => b.Rating, b => b.Rating + 1));
