using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duka.Domain.Products;
using Duka.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Duka.Infrastructure.Repository
{
    public class ProductCartRepository: IProductCartRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProductCart productCart)
        {
            await _context.ProductCarts.AddAsync(productCart);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AddProductToCartAsync(Guid cartId, int productId, int quantity)
        {
            
            var productCart = await _context.ProductCarts
                .Include(x => x.CartItems)
                .FirstOrDefaultAsync(x => x.Id == cartId);

            if (productCart == null)
            {
                return false;
            }

            var existingCartItem = productCart.CartItems
                .FirstOrDefault(x => x.ProductId == productId);

            if (existingCartItem is not null)
            {
                existingCartItem.Quantity += quantity;
                await _context.SaveChangesAsync();
                return true;
            }

            var newCartItem = new ProductCartItem
            {
                ProductCartId = cartId,
                ProductId = productId,
                Quantity = quantity
            };
            
            productCart.CartItems.Add(newCartItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(Guid id)
        {
            
            var productCart = await _context.ProductCarts.FindAsync(id);
            if (productCart is not null)
            {
                _context.ProductCarts.Remove(productCart);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ProductCart?> GetByIdAsync(Guid id)
        {
            return await _context.ProductCarts
                .AsNoTracking()
                .Include(pc => pc.CartItems)
                    .ThenInclude(pci => pci.Product)
                .Include(pc => pc.User)
                .FirstOrDefaultAsync(pc => pc.Id == id);
        }

        public async Task<IEnumerable<ProductCart>> GetByUserIdAsync(int userId)
        {
            return await _context.ProductCarts
            .AsNoTracking()
            .Include(x => x.CartItems)
                .ThenInclude(x => x.Product)
            .Where(x => x.UserId == userId)
            .ToListAsync();
        }

        public async Task<bool> RemoveProductFromCartAsync(Guid cartId, int productId)
        {
            var productCart = await _context.ProductCarts
                .Include(x => x.CartItems)
                .FirstOrDefaultAsync(x => x.Id == cartId);

            if (productCart is null)
            {
                return false;
            }

            var cartItemToRemove = productCart.CartItems
                .FirstOrDefault(x => x.ProductId == productId);

            if (cartItemToRemove is null)
            {
                return false;
            }

            productCart.CartItems.Remove(cartItemToRemove);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateAsync(ProductCart productCart)
        {
            var existingCart = await _context.ProductCarts
            .Include(x => x.CartItems)
            .FirstOrDefaultAsync(x => x.Id == productCart.Id);
        
            if (existingCart is null)
            {
                return;
            }
            
            _context.ProductCartItems.RemoveRange(existingCart.CartItems);
            
            existingCart.CartItems = productCart.CartItems;
            
            _context.ProductCarts.Update(existingCart);
            await _context.SaveChangesAsync();
            }

        public Task<bool> UpdateProductInCartAsync(Guid cartId, int productId, int newQuantity)
        {
            throw new NotImplementedException();
        }
    }
}