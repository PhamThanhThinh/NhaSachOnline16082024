using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using NhaSachOnline.Data;
using NhaSachOnline.Models;
using NhaSachOnline.Models.DTOs;
using System.Net;

namespace NhaSachOnline.Repositories
{
  public class CartRepository : ICartRepository
  {
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;

    public CartRepository(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public Task<int> AddItem(int bookId, int soluong)
    {
      throw new UnauthorizedAccessException("Người dùng chưa đăng nhập");
    }

    public async Task<bool> DoCheckout(CheckoutModel model)
    {
      using var transaction = _dbContext.Database.BeginTransaction();

      try
      {
        var userId = GetUserId();
        if (string.IsNullOrEmpty(userId))
        {
          throw new UnauthorizedAccessException("Người dùng chưa đăng nhập");
        }

        var cart = await GetCart(userId);
        if (cart is null)
        {
          throw new InvalidOperationException("lỗi, giỏ hàng trống");
        }

        var chitietgiohang = _dbContext.CartDetails
          .Where(i => i.ShoppingCartId == cart.Id).ToList();
        if (chitietgiohang.Count == 0)
        {
          throw new InvalidOperationException("giỏ hàng trống");
        }

        var trangthaidonhang = _dbContext.OrderStatuses
          .FirstOrDefault(s => s.StatusName == "Pending");
        if (trangthaidonhang is null)
        {
          throw new InvalidOperationException("đơn hàng đang chờ xử lý");
        }

        var order = new Order
        {
          UserId = userId,
          CreateDate = DateTime.UtcNow,
          Name = model.Name,
          Email = model.Email,
          MobileNumber = model.MobileNumber,
          PaymentMethod = model.PaymentMethod,
          Address = model.Address,
          IsPaid = false,
          //OrderStatus = trangthaidonhang.Id
        };

        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();

        foreach (var item in chitietgiohang)
        {
          var chitietDonHang = new OrderDetail
          {
            BookId = item.BookId,
            OrderId = order.Id,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
          };
          //_dbContext.OrderDetails.Add();
        }


      }
      catch
      {

      }

      throw new NotImplementedException();
    }

    //public async Task<int> AddItem(int bookId, int soluong)
    //{
    //  _dbContext.SaveChangesAsync();
    //}

    public async Task<ShoppingCart> GetCart(string userId)
    {
      var cart = await _dbContext.ShoppingCarts.FirstOrDefaultAsync(u => u.UserId == userId);
      return cart;
    }

    public async Task<int> GetCartItemCount(string userId = "")
    {
      throw new NotImplementedException();
    }

    public async Task<ShoppingCart> GetUserCart(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<int> RemoveItem(int bookId)
    {
      throw new NotImplementedException();
    }

    private string GetUserId()
    {
      // Nhận diện người dùng
      //var nhandiennguoidung = _contextAccessor.HttpContext.User;
      //string userId = _userManager.GetUserId(nhandiennguoidung);
      //return userId;

      // Nhận diện người dùng
      
      var httpContext = _contextAccessor.HttpContext;

      // kiểm tra
      if (httpContext?.User != null)
      {
        return _userManager.GetUserId(httpContext.User);
      }

      return null;
    }

  }
}
