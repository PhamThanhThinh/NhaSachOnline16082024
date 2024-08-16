using NhaSachOnline.Data;
using NhaSachOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace NhaSachOnline.Repositories
{
  public class HomeRepository : IHomeRepository
  {
    private readonly ApplicationDbContext _dbContext;

    public HomeRepository(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<Genre>> Genres()
    {
      return await _dbContext.Genres.ToListAsync();
    }

    public async Task<IEnumerable<Book>> LayThongTinSachTuDatabase(string keySearch = "", int theLoaiId = 0)
    {
      // chuyển đổi chuỗi sang dạng chữ thường
      keySearch = keySearch.ToLower();

      IEnumerable<Book> books =
        await (from sach in _dbContext.Books
               join theLoai in _dbContext.Genres
               on sach.GenreId equals theLoai.Id
               where 
               string.IsNullOrWhiteSpace(keySearch) 
               || (sach != null && 
               sach.BookName != null && 
               sach.BookName.ToLower().
               StartsWith(keySearch.ToLower()))
               select new Book
               {
                 Id = sach.Id,
                 BookName = sach.BookName,
                 AuthorName = sach.AuthorName,
                 Price = sach.Price,
                 Image = sach.Image,
                 GenreId = sach.GenreId,
                 GenreName = sach.GenreName,
                 Quantity = sach.Quantity
               }
             ).ToListAsync();
      return books;
    }           
  }
}
