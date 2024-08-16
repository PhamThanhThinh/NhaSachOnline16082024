using NhaSachOnline.Models;
using NhaSachOnline.Models.DTOs;

namespace NhaSachOnline.Repositories
{
  public interface ICartRepository
  {
    Task<int> AddItem(int bookId, int soluong);

    //Task DeleteItem(Book book);
    Task<int> RemoveItem(int bookId);
    
    Task<ShoppingCart> GetUserCart(int id);
    Task<ShoppingCart> GetCart(string userId);
    Task<int> GetCartItemCount(string userId = "");
    Task<bool> DoCheckout(CheckoutModel model);
  }
}
