using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YogaSix.Models;

public class HomeController : Controller
{
    private YogaSixContext context;

    public HomeController(YogaSixContext ctx)
    {
        context = ctx;
    }

    public IActionResult Index()
    {
        var classes = context.YogaClasses.Include(c => c.ChallengeLevel).OrderBy(c => c.Name).ToList();

        return View(classes);
    }
}
