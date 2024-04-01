//Instead of doing this

foreach (var blog in context.Blogs.Where(b => b.Rating < 3))
{
    context.Blogs.Remove(blog);
}

context.SaveChanges();

//Do this

context.Blogs.Where(b => b.Rating < 3).ExecuteDelete();
