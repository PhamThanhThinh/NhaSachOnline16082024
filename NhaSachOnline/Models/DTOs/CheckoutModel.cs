using System.ComponentModel.DataAnnotations;

namespace NhaSachOnline.Models.DTOs
{
  public class CheckoutModel
  {
    [Required]
    [MaxLength(20)]
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(20)]
    public string? Email { get; set; }

    [Required]
    public string? MobileNumber { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Address { get; set; }

    [Required]
    public string? PaymentMethod { get; set; }
  }
}
