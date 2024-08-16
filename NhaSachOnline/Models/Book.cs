using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaSachOnline.Models
{
  [Table("Book")]
  public class Book
  {
    public int Id { get; set; }

    // Required nghĩa là trường dữ liệu không thể trống (trên giao diện)
    // dấu ? nghĩa là cho phép null (trên database)
    [Required]
    [MaxLength(50)]
    public string? BookName { get; set; }

    [Required]
    [MaxLength(50)]
    public string? AuthorName { get; set; }

    [Required]
    public double Price { get; set; }

    // nvarchar(MAX)
    public string? Image { get; set; }

    [Required]
    public int GenreId { get; set; }
    public Genre Genre { get; set; }

    public List<OrderDetail> OrderDetail { get; set; }
    public List<CartDetail> CartDetail { get; set; }

    public Stock Stock { get; set; }

    // không ánh xạ trường dữ liệu GenreName trong bảng Genre
    [NotMapped]
    public string GenreName { get; set; }

    // không ánh xạ trường dữ liệu Quantity trong bảng Stock
    [NotMapped]
    public int Quantity { get; set; }

  }
}
