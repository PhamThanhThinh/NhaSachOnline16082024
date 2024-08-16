using NhaSachOnline.Models;

namespace NhaSachOnline.Repositories
{

  public interface IHomeRepository
  {
    Task<IEnumerable<Book>> LayThongTinSachTuDatabase(string keySearch = "", int theLoaiId = 0);
    Task<IEnumerable<Genre>> Genres();
  }
}
