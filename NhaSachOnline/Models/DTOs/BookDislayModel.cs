using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace NhaSachOnline.Models.DTOs
{
  public class BookDislayModel
  {
    public IEnumerable<Book> Books { get; set; }
    public IEnumerable<Genre> Genres { get; set; }
    public string keySearch { get; set; } = "";
    public int theLoaiId { get; set; } = 0;
  }
}
