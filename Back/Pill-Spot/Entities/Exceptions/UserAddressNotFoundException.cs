using System;

namespace Entities.Exceptions
{
    public sealed class UserAddressNotFoundException : NotFoundException
    {
        public UserAddressNotFoundException(Guid addressId)
            : base($"The user address with id: {addressId} doesn't exist in the database.")
        {
        }

        public UserAddressNotFoundException(string userId)
            : base($"No addresses found for user with id: {userId}")
        {
        }
    }
}