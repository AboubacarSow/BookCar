using BookCar.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.MVC.ViewComponents;

public class _BlogInIndexViewComponent(IBlogService blogService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var blogs = await blogService.GetLastThreeBlogs();
        var blogsToShow = blogs.Select(b=>
        new BlogFeatureViewModel
        {
            Id = b.Id,
            Title = b.Title,
            CoverImageUrl = b.CoverImageUrl,
            CommentCount = b.Comments.Count,
            CreatedDate = b.CreatedDate
        }).ToList();
        return View(blogsToShow);
    }
}