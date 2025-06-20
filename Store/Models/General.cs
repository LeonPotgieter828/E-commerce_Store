using Microsoft.EntityFrameworkCore;
using Store.Models.ViewModels;
using System;

namespace Store.Models
{
    public class General
    {
        public double Total(List<CartTable> cart)   
        {
            double total = 0;     
            foreach (var item in cart)
            {
                double cal = 0;
                cal = item.Quantity * item.Price;
                total += cal;
            }
            return total;
        }

        public void AddToCart(StoreContext _context, CartTable cart, int productID, int getID)
        {
                var getCart = _context.CartTable.Where(x => x.UserID == getID);
                var products = getCart.Select(x => x.ProductID);
                var getProduct = _context.ProductTable.FirstOrDefault(x => x.ProductID == productID);
      
                if (products.Contains(productID))
                {
                    var cartProduct = _context.CartTable.FirstOrDefault(x => x.ProductID == productID);
                    cartProduct.Quantity++;
                }
                else
                {
                    cart.ProductID = getProduct.ProductID;
                    cart.UserID = getID;
                    cart.Price = getProduct.Price;
                    cart.Quantity = 1;
                    _context.CartTable.Add(cart);
                }
                _context.SaveChanges();
        }

        public CartViewModel Model(StoreContext _context, int getID)
        {
            var cartID = _context.CartTable.FirstOrDefault(x => x.UserID == getID);
            var cart = _context.CartTable.Where(x => x.UserID == getID).ToList();
            var productIds = cart.Select(x => x.ProductID);
            var products = _context.ProductTable.Where(x => productIds.Contains(x.ProductID)).ToList();
            var total = Total(cart);

            CartViewModel model = new CartViewModel
            {
                Products = products,
                Total = total,
                Quantity = cart.Select(x => x.Quantity).ToList()
            };

            return model;
        }

        public int ProductCount()
        {
            int counter = 0;
            return counter++;
        }
    }
}
