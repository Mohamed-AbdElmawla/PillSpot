using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CartItemNotFoundException : NotFoundException
    {
        public CartItemNotFoundException(Guid cartId, Guid productId, Guid pharmacyId)
            : base($"Cart item with product: {productId} and pharmacy: {pharmacyId} " +
                  $"not found in cart: {cartId}")
        { }
        public CartItemNotFoundException(Guid cartItemId)
            : base($"Cart item with id: {cartItemId} wasn't found")
        { }
    }
}
