using Entities.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class UserAddressRepositoryExtensions
    {
        public static IQueryable<UserAddress> FilterByDefaultStatus(this IQueryable<UserAddress> addresses, bool? isDefault)
        {
            if (!isDefault.HasValue)
                return addresses;

            return addresses.Where(a => a.IsDefault == isDefault.Value);
        }

        public static IQueryable<UserAddress> Search(this IQueryable<UserAddress> addresses, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return addresses;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return addresses.Where(a =>
                a.Label.ToLower().Contains(lowerCaseTerm) ||
                a.Location.AdditionalInfo.ToLower().Contains(lowerCaseTerm));
        }
    }
}