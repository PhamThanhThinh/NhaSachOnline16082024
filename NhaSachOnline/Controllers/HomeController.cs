using Microsoft.AspNetCore.Mvc;
using NhaSachOnline.Models;
using NhaSachOnline.Repositories;
using System.Diagnostics;

namespace NhaSachOnline.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IHomeRepository _homeRepository;

    public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
    {
      _logger = logger;
      _homeRepository = homeRepository;
    }

    //public async Task<IActionResult> Index(string keySearch = "", int theLoaiId = 0)
    //{
    //  IEnumerable<Book> books = await _homeRepository.LayThongTinSachTuDatabase(keySearch, theLoaiId);
    //  IEnumerable<Genre> genres = await _homeRepository.LayThongTinSachTuDatabase(keySearch, theLoaiId);
    //  BookDislayModel bookDislayModel = new BookDislayModel
    //  {
    //    Books = books,
    //    Genres = genges,
    //    KeySearch = keySearch
    //  };

    //  return View(books);
    //}

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
